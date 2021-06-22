#include <avr/wdt.h>

#define EVERY_MS(x) \
  static uint32_t tmr;\
  bool flag = millis() - tmr >= (x);\
  if (flag) tmr += (x);\
  if (flag)

#define MOTOR_ENCODER_PIN 3
#define MOTOR_FORWARD_PIN 13 //4
#define MOTOR_BACKWARD_PIN 5
#define MOTOR_SPEED_PIN 10 //6
#define RUDDER_A_PIN 12 //7
#define RUDDER_B_PIN 8
#define RUDDER_ENABLE_PIN 11 //9
#define SENSOR_VOLTAGE_PIN A0
#define SENSOR_CURRENT_PIN A1

char incomingByte;

uint8_t Status = 0;
uint8_t Speed = 0;
uint8_t Direction = 0;
uint8_t RudderDegrees = 0;
float PowerVoltage = 0;
float PowerCurrent = 0;

void setup() {
  //wdt_enable(WDTO_4S);
  pinMode(MOTOR_ENCODER_PIN, INPUT);
  pinMode(MOTOR_FORWARD_PIN, OUTPUT);
  pinMode(MOTOR_BACKWARD_PIN, OUTPUT);
  pinMode(MOTOR_SPEED_PIN, OUTPUT);
  pinMode(RUDDER_A_PIN, OUTPUT);
  pinMode(RUDDER_B_PIN, OUTPUT);
  pinMode(RUDDER_ENABLE_PIN, OUTPUT);
  pinMode(SENSOR_VOLTAGE_PIN, INPUT);
  pinMode(SENSOR_CURRENT_PIN, INPUT);

  digitalWrite(MOTOR_FORWARD_PIN, LOW);
  digitalWrite(MOTOR_BACKWARD_PIN, LOW);
  digitalWrite(MOTOR_SPEED_PIN, LOW);
  digitalWrite(RUDDER_A_PIN, LOW);
  digitalWrite(RUDDER_B_PIN, LOW);
  digitalWrite(RUDDER_ENABLE_PIN, LOW);

  Serial.begin(9600);

  Status = 1;
}

void loop() {
  if (Serial.available() > 0 && Status != 2) {

    incomingByte = Serial.read();

    if (incomingByte == 'F') { //Forward
      ChangeDirection(1);
      for (int i = 0; i < 224; i++) {
        analogWrite(MOTOR_SPEED_PIN, i);
        delay(2);
      }
    }

    if (incomingByte == 'B') { //Backward
      ChangeDirection(0);
      for (int i = 0; i < 224; i++) {
        analogWrite(MOTOR_SPEED_PIN, i);
        delay(2);
      }
      analogWrite(MOTOR_SPEED_PIN, 255);
    }

    if (incomingByte == 'S') { //Stop
      analogWrite(MOTOR_SPEED_PIN, 0);
      digitalWrite(RUDDER_ENABLE_PIN, LOW);
    }

    if (incomingByte == 'D') { //Stop
      digitalWrite(RUDDER_ENABLE_PIN, LOW);
    }
  }

  if (incomingByte == 'L') { //Left
    digitalWrite(RUDDER_A_PIN, LOW);
    digitalWrite(RUDDER_B_PIN, HIGH);
    delay(5);
    digitalWrite(RUDDER_ENABLE_PIN, HIGH);
  }

  if (incomingByte == 'R') { //Right
    digitalWrite(RUDDER_A_PIN, HIGH);
    digitalWrite(RUDDER_B_PIN, LOW);
    delay(5);
    digitalWrite(RUDDER_ENABLE_PIN, HIGH);
  }

  if (incomingByte == 'E') { //Enable emergency
    Status = 2;
  }
  
  EVERY_MS(1500) {
    //PowerCurrent = analogRead(SENSOR_CURRENT_PIN / 1024.0 * 5);
    //PowerVoltage = analogRead(SENSOR_VOLTAGE_PIN / 1024.0 * 5);
    Serial.println((String)Status + " " + (String)PowerCurrent + " " + (String)PowerVoltage + " " + (String)Direction + " " + (String)RudderDegrees); //Sending telemetry
    //wdt_reset();
  }
}

void ChangeDirection(int direct) {
  Direction = direct;
  switch (Direction) {
    case 0:
      digitalWrite(MOTOR_FORWARD_PIN, LOW);
      delay(10);
      digitalWrite(MOTOR_BACKWARD_PIN, HIGH);
      break;
    case 1:
      digitalWrite(MOTOR_FORWARD_PIN, HIGH);
      delay(10);
      digitalWrite(MOTOR_BACKWARD_PIN, LOW);
      break;
  }
}
