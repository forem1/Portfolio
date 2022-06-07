#include <SPI.h>
#include <Adafruit_GFX.h>
#include <Max72xxPanel.h>

Max72xxPanel matrix = Max72xxPanel(5, 1, 1);
int wait = 100; // In milliseconds
int spacer = 1;
int width = 5 + spacer; // The font width is 5 pixels

String stringUART = ""; // Переменная сбора принятых командных символов в строку
bool startedUART; // переменная начала приема командных данных по uart
uint8_t indexUART = 0; // Индекс принятого аргумента командного режима

byte mask[8] = {
  0b00000000,
  0b00000000,
  0b00000000,
  0b00000000,
  0b00000000,
  0b00000000,
  0b00000000,
  0b00000000
};

String receivedTicker = "";

void setup() {
  Serial.begin(115200);
  //ticker("");
  //pixelsDraw();
  matrix.fillScreen(LOW);
  matrix.write();
}

void loop() {
  if (Serial.available() > 0) {
    char incomingByte = Serial.read();
    if (incomingByte != ',' && incomingByte != ';') stringUART += incomingByte;
    else {
      switch (indexUART) {
        case 0:
          receivedTicker = stringUART;
          receivedTicker.replace(":", "");
          break;
        case 1:
          mask[0] = (byte)stringUART.toInt();
          break;
        case 2:
          mask[1] = (byte)stringUART.toInt();
          break;
        case 3:
          mask[2] = (byte)stringUART.toInt();
          break;
        case 4:
          mask[3] = (byte)stringUART.toInt();
          break;
        case 5:
          mask[4] = (byte)stringUART.toInt();
          break;
        case 6:
          mask[5] = (byte)stringUART.toInt();
          break;
        case 7:
          mask[6] = (byte)stringUART.toInt();
          break;
        case 8:
          mask[7] = (byte)stringUART.toInt();
          break;
      }
      stringUART = "";                              // очищаем строку
      indexUART++;                                  // переходим к парсингу следующего элемента массива
    }
    if (incomingByte == '*') {                               // если это *
      startedUART = true;                      // поднимаем флаг, что можно парсить
      indexUART = 0;                                  // сбрасываем индекс
      stringUART = "";                                // очищаем строку
    }
    if (incomingByte == ';') {  // если таки приняли ; - конец парсинга
      startedUART = false;                     // сброс
      if(receivedTicker.length() > 0) ticker(receivedTicker);
      else pixelsDraw();
    }
  }
}

void pixelsDraw() {
  for (int y = 0; y < 8; y++ ) {            // Передача массива
    for (int x = 0; x < 8; x++ ) {
      matrix.drawPixel(x, y, mask[y] & (1 << x));
    }
  }
  matrix.write();
}

void ticker(String tape) {
  for ( int i = 0 ; i < width * tape.length() + matrix.width() - spacer; i++ )
  {
    matrix.fillScreen(LOW);

    int letter = i / width;                   // номер символа выводимого на матрицу

    int x = (matrix.width() - 1) - i % width;
    int y = (matrix.height() - 8) / 2;         // отцентрировать текст по вертикали

    while ( x + width - spacer >= 0 && letter >= 0 ) {
      if ( letter < tape.length() ) {
        matrix.drawChar(x, y, tape[letter], HIGH, LOW, 1);
      }
      letter--;
      x -= width;
    }
    matrix.write();                       // выведим значения на матрицу
    delay(wait);
  }
  receivedTicker = "";
}
