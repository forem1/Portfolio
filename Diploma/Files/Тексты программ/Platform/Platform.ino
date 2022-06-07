#include "Platform.h"

Platform platform;

void setup() {
  pinMode(13, OUTPUT); //Debug signal
  pinMode(A8, INPUT_PULLUP);
  Serial.begin(115200); //Debug or platform's load
  Serial1.begin(9600); //GPS

  platform.begin("testPlatf", "8tegqHu6VZ");
  platform.GPIOSetup(GPIO_DIGITALOUT, GPIO_DIGITALOUT, GPIO_DIGITALOUT, GPIO_DIGITALOUT);
  platform.initUARTControlData(platform);
  platform.initMPU();
}

void loop() {
  while (1) { //Speed-up bug
    //PORTB |= (1 << 7); //13 test square generator
    //PORTB &= ~ (1 << 7); //13

    if (millis() % 50 == 0) {
      //platform.sendUARTControlData("^:asd;\r\n");
      platform.getGPSData(&Serial1);
      platform.getMPUData();
    }

    //  if (Serial.available() > 0) { //Segment for test bridge between PC and platform's load
    //    platform.sendUARTCommandData("^:" + Serial.readString() + ";");
    //  }

    //platform.startBench();
    //delay(500);
    //platform.getGPSData(&Serial1);
    //platform.stopBench(&Serial);
  }
}

/* TODO
    Конфигуратор GPIO, запись напрямую через текстовые команды и работа с интерфейсами через data в dataIncome
    Попробовать скорость 2M бод между нагрузкой и платформой

    Тест режимов emode, start, stop!!! Не пройдено

    %:s,100,s,10,1,0,0,0,1;
*/
