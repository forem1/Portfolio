#include "Platform.h"

#define cbi(sfr, bit) (_SFR_BYTE(sfr) &= ~_BV(bit))
#define sbi(sfr, bit) (_SFR_BYTE(sfr) |= _BV(bit))

Platform ptf; // Class instance call

Platform::Platform() {} // Class constructor

void Platform::begin(String name, String key) {
  PlatformName = name;
  PlatformKey = key;


  pinMode(7, OUTPUT);     // Motor key A, 7
  pinMode(4, OUTPUT);     // Motor key A, 4
  pinMode(8, OUTPUT);     // Motor key B, 8
  pinMode(9, OUTPUT);     // Motor key B, 9
  pinMode(5, OUTPUT);     // Motor PWM pin, 5
  pinMode(6, OUTPUT);     // Motor PWM pin, 6
  pinMode(A2, INPUT);     // Current sensor pin, A2
  pinMode(A3, INPUT);     // Current sensor pin, A3
  pinMode(A7, INPUT);     // Voltage sensor pin, A7

  pinMode(52, OUTPUT);    // GPIO1 pin
  pinMode(50, OUTPUT);    // GPIO2 pin
  pinMode(51, OUTPUT);    // GPIO3 pin
  pinMode(53, OUTPUT);    // GPIO4 pin

  sbi(TCCR3A, COM3A1);    // PWM, 5
  sbi(TCCR4A, COM4A1);    // PWM, 6

  mainParameters.systemstatus = STATUS_WORK;

  if (!digitalRead(A8)) mainParameters.extid = 1;
  else mainParameters.extid = 0;
}

void Platform::makeMove(uint8_t direction, uint8_t speed, uint8_t acceleration) {
  uint8_t dividerForRightMotor = 0;
  uint8_t dividerForLeftMotor = 0;

  PORTH &= ~ (1 << 4); //7, LOW A
  PORTG &= ~ (1 << 5); //4, LOW A
  PORTH &= ~ (1 << 5); //8, LOW B
  PORTH &= ~ (1 << 6); //9, LOW B

  switch (direction) {
    case 0:
      PORTH |= (1 << 4); //7, HIGH A
      PORTH |= (1 << 6); //9, HIGH B
      break;
    case 1:
      PORTG |= (1 << 5); //4, HIGH A
      PORTH |= (1 << 5); //8, HIGH B
      break;
    case 2:
      PORTH &= ~ (1 << 4); //7, LOW A
      PORTH |= (1 << 5); //8, HIGH B

      PORTG &= ~ (1 << 5); //4, LOW A
      PORTH |= (1 << 6); //9, HIGH B
      break;
    case 3:
      PORTH |= (1 << 4); //7, HIGH A
      PORTH &= ~ (1 << 5); //8, LOW B

      PORTG |= (1 << 5); //4, HIGH A
      PORTH &= ~ (1 << 6); //9, LOW B
      break;
    case 4:
      PORTG |= (1 << 5); //4, HIGH A
      PORTH |= (1 << 5); //8, HIGH B

      dividerForRightMotor = 5;
      dividerForLeftMotor = 0; //Decrease left speed
      break;
    case 5:
      PORTG |= (1 << 5); //4, HIGH A
      PORTH |= (1 << 5); //8, HIGH B

      dividerForRightMotor = 0; //Decrease right speed
      dividerForLeftMotor = 5;
      break;
    case 6:
      PORTH |= (1 << 4); //7, HIGH A
      PORTH |= (1 << 6); //9, HIGH B

      dividerForRightMotor = 5;
      dividerForLeftMotor = 0; //Decrease left speed
      break;
    case 7:
      PORTH |= (1 << 4); //7, HIGH A
      PORTH |= (1 << 6); //9, HIGH B

      dividerForRightMotor = 0; //Decrease right speed
      dividerForLeftMotor = 5;
      break;
  }

  /*if(acceleration == 1) {
  	for(uint16_t i = 0; i <= map(speed, 0, 100, 0, 255); i++) { //Не работает. работает. да...
  		analogWrite(pwmpin[0], i);
  		analogWrite(pwmpin[1], i);
  		delay(10);
  	}
    }
    else {*/

  OCR3A = map(speed<5?speed:speed-dividerForLeftMotor, 0, 100, 0, 255); // set pwm duty
  OCR4A = map(speed<5?speed:speed-dividerForRightMotor, 0, 100, 0, 255);

  //}
}

void Platform::brake(uint8_t mode) {
  if (mode == 1) {
    OCR3A = 0; // set pwm duty
    OCR4A = 0;

    //Rapid braking, short circuit motor
    PORTH |= (1 << 4); //7, HIGH
    PORTG |= (1 << 5); //4, HIGH
    PORTH |= (1 << 5); //8, HIGH
    PORTH |= (1 << 6); //9, HIGH

    delay(50);

    //Return keys to low state
    PORTH &= ~ (1 << 4); //7, LOW
    PORTG &= ~ (1 << 5); //4, LOW
    PORTH &= ~ (1 << 5); //8, LOW
    PORTH &= ~ (1 << 6); //9, LOW
  }
  else {
    OCR3A = 0; // set pwm duty
    OCR4A = 0;

    //Soft inertional braking
    PORTH &= ~ (1 << 4); //7, LOW
    PORTG &= ~ (1 << 5); //4, LOW
    PORTH &= ~ (1 << 5); //8, LOW
    PORTH &= ~ (1 << 6); //9, LOW
  }
}

//Telemetry section

bool Platform::initUARTControlData(Platform platform, int baudrate) {
  UCSR2A = 1 << U2X1; //UCSR2A = 1 << U2X1 for 115200
  // assign the baud_setting, a.k.a. ubrr (USART Baud Rate Register)
  /* Set baud rate */
  UBRR2H = baudrate >> 8;
  UBRR2L = baudrate;

  //Permission to receive and transmit via USART, interrupts on arrival and on devastation
  UCSR2B = (1 << RXCIE2) | (1 << TXCIE2) | (1 << RXEN2) | (1 << TXEN2);
  UCSR2C = (1 << UCSZ21) | (1 << UCSZ20); //Word's size 8 bits
  sei();

  ptf = platform;
  return true;
}

bool Platform::initUARTControlData(Platform platform) {
  UCSR2A = 1 << U2X1;
  // assign the baud_setting, a.k.a. ubrr (USART Baud Rate Register)
  /* Set baud rate */
  UBRR2H = 34 >> 8; //Value '34' for 57600 baudrate 
  UBRR2L = 34;

  //Permission to receive and transmit via USART, interrupts on arrival and on devastation
  UCSR2B = (1 << RXCIE2) | (1 << TXCIE2) | (1 << RXEN2) | (1 << TXEN2);
  UCSR2C = (1 << UCSZ21) | (1 << UCSZ20); //Word's size 8 bits
  sei();

  ptf = platform;
  return true;
}


ISR(USART2_RX_vect) { //ISR UART2 handler
  if(ptf.mainParameters.systemstatus != STATUS_EMODE) ptf.getUARTControlData();
}

void Platform::getUARTControlData(void) {
  while ( !(UCSR2A & (1 << RXC2)) );
  char incomingByte = UDR2; // Read income char

  //-------------------------------------------------Who am I section-------------------------------------------------
  if (incomingByte == '@' && !startedUARTCommandRecieve && !startedUARTLoadRecieve) {
    sendUARTControlData("@:"+PlatformName+","+PlatformKey+";");
  }

  //-------------------------------------------------Load UART command section-------------------------------------------------
  if (incomingByte == '*') {
    startedUARTLoadRecieve = true;
    stringUARTLoad = "";
  }
  if (incomingByte != ';' && startedUARTLoadRecieve) stringUARTLoad += incomingByte;
  else {
    stringUARTLoad += ";";

    for (uint32_t i = 0; i <= strlen(stringUARTLoad.c_str()); ++i) { //UART0 transmit
      /* Wait for empty transmit buffer */
      while ( !( UCSR0A & (1 << UDRE0)) );
      /* Put data into buffer, sends the data */
      UDR0 = stringUARTLoad[i];
    }

    startedUARTLoadRecieve = false;
    stringUARTLoad = "";
  }

  //-------------------------------------------------Move UART command section-------------------------------------------------
  if (incomingByte != ',' && incomingByte != ';' && startedUARTCommandRecieve && !startedUARTLoadRecieve) {  // if it isn't space and end
    stringUARTCommand += incomingByte;                                            // Add to sting
  } else {                                                                        // If it's a space or ;
      switch (indexUARTCommand) {
        case 0:
          controlDataIn.move = stringUARTCommand[1];
          break;
        case 1:
          controlDataIn.speed = stringUARTCommand.toInt();
          break;
        case 2:
          controlDataIn.value = stringUARTCommand[0];
          break;
        case 3:
          controlDataIn.azimuthloc = stringUARTCommand.toInt();
          break;
        case 4:
          controlDataIn.gpio1 = stringUARTCommand.toFloat();
          if(GPIO1 == GPIO_DIGITALOUT) digitalWrite(52, stringUARTCommand.toFloat());
          break;
        case 5:
          controlDataIn.gpio2 = stringUARTCommand.toFloat();
          if(GPIO2 == GPIO_DIGITALOUT) digitalWrite(50, stringUARTCommand.toFloat());
          break;
        case 6:
          controlDataIn.gpio3 = stringUARTCommand.toFloat();
          if(GPIO3 == GPIO_DIGITALOUT) digitalWrite(51, stringUARTCommand.toFloat());
          break;
        case 7:
          controlDataIn.gpio4 = stringUARTCommand.toFloat();
          if(GPIO4 == GPIO_DIGITALOUT) digitalWrite(53, stringUARTCommand.toFloat());
          break;
        case 8:
          controlDataIn.systemstatus = stringUARTCommand.toInt();
          ptf.mainParameters.systemstatus = controlDataIn.systemstatus;
          break;
        case 9:
          controlDataIn.data = stringUARTCommand;
          break;
      }
    stringUARTCommand = "";                              // Clear string
    indexUARTCommand++;                                  // Select next parsing section of array
  }
  if (incomingByte == '%') {        
    startedUARTCommandRecieve = true;                     
    indexUARTCommand = 0;                 
    stringUARTCommand = "";            
  }
  if (incomingByte == ';' && startedUARTCommandRecieve) {
    startedUARTCommandRecieve = false;                    

    //Заполняем структуру и передаем её
    if(mainParameters.systemstatus != STATUS_STOP && mainParameters.systemstatus != STATUS_EMODE) {
      controlDataOut.move = controlDataIn.move;
      controlDataOut.speed = controlDataIn.speed;
      controlDataOut.value = controlDataIn.value;
    }
    controlDataOut.lcurr = analogRead(A3) * 0.038;   //Current in Amps
    controlDataOut.rcurr = analogRead(A2) * 0.038;
    // controlDataOut.accx = AccX;
    // controlDataOut.accy = AccY;
    // controlDataOut.accz = AccZ;
    // controlDataOut.gyrox = GyroX;
    // controlDataOut.gyroy = GyroY;
    // controlDataOut.gyroz = GyroZ;
    controlDataOut.magx = 0;
    controlDataOut.magy = 0;
    controlDataOut.magz = 0;
    controlDataOut.lan = mainParameters.GPSLatitude;
    controlDataOut.lon = mainParameters.GPSLongitude;
    controlDataOut.vbat = ((analogRead(A7)* 5.0) / 1024.0)/0.337;
    controlDataOut.systemstatus = mainParameters.systemstatus;
    controlDataOut.extid = mainParameters.extid;
    controlDataOut.extstatus = mainParameters.systemstatus;

    String outgoingDataString = "&:" + String(controlDataOut.move) + "," + String(controlDataOut.speed) + "," + String(controlDataOut.value) + "," + String(controlDataOut.lcurr) + "," + String(controlDataOut.rcurr) + "," + String(controlDataOut.accx) + "," + String(controlDataOut.accy) + "," + String(controlDataOut.accz) + "," + String(controlDataOut.gyrox) + "," + String(controlDataOut.gyroy) + "," + String(controlDataOut.gyroz) + "," + String(controlDataOut.magx) + "," + String(controlDataOut.magy) + "," + String(controlDataOut.magz) + "," + controlDataOut.lan + "," + controlDataOut.lon + "," + String(controlDataOut.vbat) + "," + String(controlDataOut.systemstatus) + "," + String(controlDataOut.extid) + "," + String(controlDataOut.extstatus) + ";\r\n";
    //Serial.print(outgoingDataString);
    sendUARTControlData(outgoingDataString);

    if(ptf.mainParameters.systemstatus != STATUS_STOP && ptf.mainParameters.systemstatus != STATUS_EMODE) {
      switch (controlDataIn.move) {
        case 'f':
          makeMove(FORWARD, controlDataIn.speed, (controlDataIn.value == 'f') ? FAST : SLOW);
          break;
        case 'b':
          makeMove(BACKWARD, controlDataIn.speed, (controlDataIn.value == 'f') ? FAST : SLOW);
          break;
        case 'l':
          makeMove(LEFT, controlDataIn.speed, (controlDataIn.value == 'f') ? FAST : SLOW);
          break;
        case 'r':
          makeMove(RIGHT, controlDataIn.speed, (controlDataIn.value == 'f') ? FAST : SLOW);
          break;
        case 'a':
          makeMove(FORWARDLEFT, controlDataIn.speed, (controlDataIn.value == 'f') ? FAST : SLOW);
          break;
        case 'c':
          makeMove(FORWARDRIGHT, controlDataIn.speed, (controlDataIn.value == 'f') ? FAST : SLOW);
          break;
        case 'd':
          makeMove(BACKWARDLEFT, controlDataIn.speed, (controlDataIn.value == 'f') ? FAST : SLOW);
          break;
        case 'e':
          makeMove(BACKWARDRIGHT, controlDataIn.speed, (controlDataIn.value == 'f') ? FAST : SLOW);
          break;
        case 's':
          brake(STOP);
          break;
      }
    }
    else brake(BRAKE);
  }
}

void Platform::sendUARTControlData(String outgoingDataString)
{
  for (uint32_t i = 0; i <= strlen(outgoingDataString.c_str()); ++i) {
    /* Wait for empty transmit buffer */
    while ( !( UCSR2A & (1 << UDRE2)) );
    /* Put data into buffer, sends the data */
    UDR2 = outgoingDataString[i];
  }
}

bool Platform::getGPSData(Stream* _serial) {
  String stringGPS = "";
  if (_serial->available() > 0) {
    stringGPS = _serial->readStringUntil(13); //NMEA data ends with 'return' character, which is ascii(13)
    stringGPS.trim();                      // they say NMEA data starts with "$", but the Arduino doesn't think so.
    //Serial.println(stringGPS);         //All the raw sentences will be sent to monitor, if you want them, maybe to see the labels and data order.

    //Start Parsing by finding data, put it in a string of character array, then removing it, leaving the rest of thes sentence for the next 'find'
    if (stringGPS.startsWith("$GPGLL") || stringGPS.startsWith("$GLGLL") || stringGPS.startsWith("$GAGLL") || stringGPS.startsWith("$BDGLL") || stringGPS.startsWith("$GQGLL") || stringGPS.startsWith("$GNGLL")) { //I picked this sentence, you can pick any of the other labels and rearrange/add sections as needed.
      //Serial.println(stringGPS);     // display raw GLL data in Serial Monitor
      // mine looks like this: "$GPGLL,4053.16598,N,10458.93997,E,224431.00,A,D*7D"

      //This section gets repeated for each delimeted bit of data by looking for the commas
      //Find Lattitude is first in GLL sentence, other senetences have data in different order
      int Pos = stringGPS.indexOf(','); //look for comma delimetrer
      stringGPS.remove(0, Pos + 1); // Remove Pos+1 characters starting at index=0, this one strips off "$GPGLL" in my sentence
      Pos = stringGPS.indexOf(','); //looks for next comma delimetrer, which is now the first comma because I removed the first segment
      char Lat[Pos];            //declare character array Lat with a size of the dbit of data
      for (int i = 0; i <= Pos - 1; i++) { // load charcters into array
        Lat[i] = stringGPS.charAt(i);
      }
      //Serial.print(Lat);          // display raw latitude data in Serial Monitor, I'll use Lat again in a few lines for converting
      //repeating with a different char array variable
      //Get Lattitude North or South
      stringGPS.remove(0, Pos + 1);
      Pos = stringGPS.indexOf(',');
      char LatSide[Pos];           //declare different variable name
      for (int i = 0; i <= Pos - 1; i++) {
        LatSide[i] = stringGPS.charAt(i); //fill the array
        //Serial.println(LatSide[i]);       //display N or S
      }

      //convert the variable array Lat to degrees Google can use
      float LatAsFloat = atof (Lat);            //atof converts the char array to a float type
      float LatInDeg;
      if (LatSide[0] == char(78)) {     //char(69) is decimal for the letter "N" in ascii chart
        LatInDeg = convertRawCoordinatesToDegrees(LatAsFloat);  //call the conversion funcion (see below)
      }
      if (LatSide[0] == char(83)) {     //char(69) is decimal for the letter "S" in ascii chart
        LatInDeg = -( convertRawCoordinatesToDegrees(LatAsFloat));  //call the conversion funcion (see below)
      }
      if(LatInDeg > 0 && String(LatInDeg, 8) != "") ptf.mainParameters.GPSLatitude = String(LatInDeg, 8); //TEMP SOLUTION
      //Serial.println(LatInDeg, 15); //display value Google can use in Serial Monitor, set decimal point value high
      //repeating with a different char array variable
      //Get Longitude
      stringGPS.remove(0, Pos + 1);
      Pos = stringGPS.indexOf(',');
      char Longit[Pos];             //declare different variable name
      for (int i = 0; i <= Pos - 1; i++) {
        Longit[i] = stringGPS.charAt(i);    //fill the array
      }
      //Serial.print(Longit);      //display raw longitude data in Serial Monitor
      //repeating with a different char array variable
      //Get Longitude East or West
      stringGPS.remove(0, Pos + 1);
      Pos = stringGPS.indexOf(',');
      char LongitSide[Pos];         //declare different variable name
      for (int i = 0; i <= Pos - 1; i++) {
        LongitSide[i] = stringGPS.charAt(i);    //fill the array
        //Serial.println(LongitSide[i]);        //display raw longitude data in Serial Monitor
      }
      //convert to degrees Google can use
      float LongitAsFloat = atof (Longit);    //atof converts the char array to a float type
      float LongInDeg;
      if (LongitSide[0] == char(69)) {     //char(69) is decimal for the letter "E" in ascii chart
        LongInDeg = convertRawCoordinatesToDegrees(LongitAsFloat); //call the conversion funcion (see below
      }
      if (LongitSide[0] == char(87)) {      //char(87) is decimal for the letter "W" in ascii chart
        LongInDeg = -(convertRawCoordinatesToDegrees(LongitAsFloat)); //call the conversion funcion (see below
      }
      if(LongInDeg > 0 && String(LongInDeg, 8) != "") ptf.mainParameters.GPSLongitude = String(LongInDeg, 8); //TEMP SOLUTION
      //Serial.println(LongInDeg, 15); //display value Google can use in Serial Monitor, set decimal point value high
      //repeating with a different char array variable
      //Get TimeStamp - GMT
      stringGPS.remove(0, Pos + 1);
      Pos = stringGPS.indexOf(',');
      char TimeStamp[Pos];          //declare different variable name
      for (int i = 0; i <= Pos - 1; i++) {
        TimeStamp[i] = stringGPS.charAt(i);       //fill the array
      }
      ptf.mainParameters.GPSTimestamp = TimeStamp; //TEMP SOLUTION
      //Serial.print(TimeStamp);   //display raw longitude data in Serial Monitor, GMT
      //Serial.println(String(LongInDeg, 8));
    }
  }
  return true;
}

void Platform::initMPU() {
  Wire.begin();
  Wire.setClock(400000);

  I2CwriteByte(MPU6050_ADDRESS, 29, 0x06);// Set accelerometers low pass filter at 5Hz !
  I2CwriteByte(MPU6050_ADDRESS, 26, 0x06); // Set gyroscope low pass filter at 5Hz !

  // Configure gyroscope range
  I2CwriteByte(MPU6050_ADDRESS, 27, 0x6B); GyroDevider = 131; //GYRO_FULL_SCALE_250_DPS !
  //I2CwriteByte(MPU6050_ADDRESS, 27, 0x08); GyroDevider = 65.5; //GYRO_FULL_SCALE_500_DPS
  //I2CwriteByte(MPU6050_ADDRESS, 27, 0x10); GyroDevider = 32.8; //GYRO_FULL_SCALE_1000_DPS
  // I2CwriteByte(MPU6050_ADDRESS, 27, 0x18); GyroDevider = 16.4; //GYRO_FULL_SCALE_2000_DPS

  // Configure accelerometers range
  I2CwriteByte(MPU6050_ADDRESS, 28, 0x00); AccDevider = 16384; //ACC_FULL_SCALE_2_G !
  //I2CwriteByte(MPU6050_ADDRESS, 28, 0x08); AccDevider = 8192; //ACC_FULL_SCALE_4_G
  //I2CwriteByte(MPU6050_ADDRESS, 28, 0x10); AccDevider = 4096; //ACC_FULL_SCALE_8_G
  //I2CwriteByte(MPU6050_ADDRESS, 28, 0x18); AccDevider = 2048; //ACC_FULL_SCALE_16_G


  while (MPU_Calib_Counter < 200) {
    uint8_t Buf[14];
    I2Cread(MPU6050_ADDRESS, 0x3B, 14, Buf);

    //Get values from sensor
    GyroX = -(Buf[0] << 8 | Buf[1]);
    GyroY = -(Buf[2] << 8 | Buf[3]);
    GyroZ = Buf[4] << 8 | Buf[5];

    // Sum all readings
    GyroErrorX = GyroErrorX + (GyroX / GyroDevider);
    GyroErrorY = GyroErrorY + (GyroY / GyroDevider);
    GyroErrorZ = GyroErrorZ + (GyroZ / GyroDevider);
    MPU_Calib_Counter++;
  }

  //Divide the sum by 200 to get the error value
  GyroErrorX = GyroErrorX / 200;
  GyroErrorY = GyroErrorY / 200;
  GyroErrorZ = GyroErrorZ / 200;
  MPU_Calib_Counter = 0;

  while (MPU_Calib_Counter < 200) {
    uint8_t Buf[14];
    I2Cread(MPU6050_ADDRESS, 0x3B, 14, Buf);

    //Get values from sensor
    AccX = (Buf[8] << 8 | Buf[9]) / AccDevider;
    AccY = (Buf[10] << 8 | Buf[11]) / AccDevider;
    AccZ = (Buf[12] << 8 | Buf[13]) / AccDevider;

    // Sum all readings
    AccErrorX = AccErrorX + ((atan((AccY) / sqrt(pow((AccX), 2) + pow((AccZ), 2))) * 180 / PI));
    AccErrorY = AccErrorY + ((atan(-1 * (AccX) / sqrt(pow((AccY), 2) + pow((AccZ), 2))) * 180 / PI));
    MPU_Calib_Counter++;
  }

  //Divide the sum by 200 to get the error value
  AccErrorX = AccErrorX / 200;
  AccErrorY = AccErrorY / 200;
  MPU_Calib_Counter = 0;

#if DEBUGGYRO || DEBUGACC
  Serial.print(F("AccErrorX: "));
  Serial.println(AccErrorX);
  Serial.print(F("AccErrorY: "));
  Serial.println(AccErrorY);
  Serial.print(F("GyroErrorX: "));
  Serial.println(GyroErrorX);
  Serial.print(F("GyroErrorY: "));
  Serial.println(GyroErrorY);
  Serial.print(F("GyroErrorZ: "));
  Serial.println(GyroErrorZ);
#endif
}

void Platform::getMPUData() {
  uint8_t Buf[14];

  I2Cread(MPU6050_ADDRESS, 0x3B, 14, Buf); // Read accelerometer and gyroscope

  //Gyroscope
  GyroX = (Buf[0] << 8 | Buf[1]) / GyroDevider;
  GyroY = (Buf[2] << 8 | Buf[3]) / GyroDevider;
  GyroZ = (Buf[4] << 8 | Buf[5]) / GyroDevider;

  // Correct the outputs with the calculated error values
  GyroX = GyroX + abs(GyroErrorX); // GyroErrorX ~(-0.56)
  GyroY = GyroY + abs(GyroErrorY); // GyroErrorY ~(2)
  GyroZ = GyroZ + abs(GyroErrorZ); // GyroErrorZ ~ (-0.8)

  //Temperature
  Temperature = (Buf[6] << 8 | Buf[7]) / 340.0 + 36.53;

  // Accelerometer
  AccX = (Buf[8] << 8 | Buf[9]) / AccDevider;
  AccY = (Buf[10] << 8 | Buf[11]) / AccDevider;
  AccZ = (Buf[12] << 8 | Buf[13]) / AccDevider;

  // Display values
  ptf.controlDataOut.accx = AccX;
  ptf.controlDataOut.accy = AccY;
  ptf.controlDataOut.accz = AccZ;
  ptf.controlDataOut.gyrox = GyroX;
  ptf.controlDataOut.gyroy = GyroY;
  ptf.controlDataOut.gyroz = GyroZ;
  //Serial.println(ptf.controlDataOut.gyrox);

  // Gyroscope
#if DEBUGGYRO
  Serial.print(F("GyroX: "));
  Serial.println((int)GyroX, DEC);
  Serial.print(F("GyroY: "));
  Serial.println((int)GyroY, DEC);
  Serial.print(F("GyroZ: "));
  Serial.println((int)GyroZ, DEC);
  Serial.println((int)Temperature, DEC);
#endif

  // Accelerometer
#if DEBUGACC
  Serial.print(F("AccX: "));
    Serial.println(AccX, DEC);
    Serial.print(F("AccY: "));
    Serial.println(AccY, DEC);
    Serial.print(F("AccZ: "));
    Serial.println (AccZ, DEC);
#endif

}

//MasterLink section
void Platform::GPIOSetup(uint8_t GPIO_1, uint8_t GPIO_2, uint8_t GPIO_3, uint8_t GPIO_4) {
  GPIO1 = GPIO_1;
  GPIO2 = GPIO_2;
  GPIO3 = GPIO_3;
  GPIO4 = GPIO_4;

  if(GPIO_1 == GPIO_OFF || GPIO_1 == GPIO_DIGITALOUT) pinMode(52, OUTPUT);
  else pinMode(52, INPUT);

  if(GPIO_2 == GPIO_OFF || GPIO_2 == GPIO_DIGITALOUT) pinMode(50, OUTPUT);
  else pinMode(50, INPUT);

  if(GPIO_3 == GPIO_OFF || GPIO_3 == GPIO_DIGITALOUT) pinMode(51, OUTPUT);
  else pinMode(51, INPUT);

  if(GPIO_4 == GPIO_OFF || GPIO_4 == GPIO_DIGITALOUT) pinMode(53, OUTPUT);
  else pinMode(53, INPUT);
}

//Another useful functions
void Platform::startBench() {
  TCCR1A = 0x00;            // Turn off
  TCCR1B = 0x00;            // Turn off
  TCNT1 = 0x00;             // Reset counter
  TCCR1B = 0x01;            // Start timer
}

void Platform::stopBench(Stream* _serial) {
  TCCR1B = 0x00;            // Stop timer
  uint32_t count = TCNT1 - 2; // Minus 2 ticks on actions

  _serial->print("ticks: ");
  _serial->print(count);
  _serial->print("  ");
  _serial->print("time (us): ");
  _serial->println(count * (float)(1000000.0f / F_CPU), 4);
}

float Platform::convertRawCoordinatesToDegrees(float RawDegrees) {
  float RawAsFloat = RawDegrees;
  int firstdigits = ((int)RawAsFloat) / 100; // Get the first digits by turning f into an integer, then doing an integer divide by 100;
  float nexttwodigits = RawAsFloat - (float)(firstdigits * 100);
  float Converted = (float)(firstdigits + nexttwodigits / 60.0);
  return Converted;
}

void Platform::I2Cread(uint8_t Address, uint8_t Register, uint8_t Nbytes, uint8_t* Data)
{
  // Set register address
  Wire.beginTransmission(Address);
  Wire.write(Register);
  Wire.endTransmission();

  // Read Nbytes
  Wire.requestFrom(Address, Nbytes);
  uint8_t index = 0;
  while (Wire.available())
    Data[index++] = Wire.read();
}

void Platform::I2CwriteByte(uint8_t Address, uint8_t Register, uint8_t Data)
{
  // Set register address
  Wire.beginTransmission(Address);
  Wire.write(Register);
  Wire.write(Data);
  Wire.endTransmission();
}
