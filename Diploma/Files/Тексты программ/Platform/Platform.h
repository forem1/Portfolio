#pragma once
#include <Arduino.h>
#include <avr/interrupt.h>
#include <Wire.h>
#define _LIB_VERSION        1.0

#define DEBUGGYRO           false
#define DEBUGACC            false
#define DEBUGUART           false
#define DEBUGGPS            false

#define MPU6050_ADDRESS     0x68

#define BACKWARD            0       // Move backward
#define FORWARD             1       // Move forward
#define LEFT                2       // Move counterclock-wise
#define RIGHT               3       // Move counterclock
#define FORWARDLEFT         4       // Move forward and left
#define FORWARDRIGHT        5       // Move forward and right
#define BACKWARDLEFT        6       // Move backward and left
#define BACKWARDRIGHT       7       // Move backward and right

#define BRAKE               1       // Value for rapid braking
#define STOP                0       // Value for inertional braking
#define FAST                0       // Value for rapid acceleration
#define SLOW                1       // Value for soft acceleration

#define STATUS_STOP         0       // Stop, command processing is discontinued
#define STATUS_WORK         1       // Work, exchange of commands
#define STATUS_SHUTDOWN     2       // Ready to Shut Down
#define STATUS_ECO          3       // Energy saving mode
#define STATUS_EMODE        4       // Emergency mode
#define STATUS_ERROR        5       // Unexpected system error
#define STATUS_EXEPTION     6       // Work, have problems

#define GPIO_OFF            0       // GPIO off
#define GPIO_DIGITALIN      1       // GPIO as digital input
#define GPIO_DIGITALOUT     2       // GPIO as digital output
#define GPIO_ANALOGIN       3       // GPIO as analog input

struct DataIncome { 				// Structure of data coming from PC to UART
  char move;
  uint8_t speed;
  char value;
  uint8_t azimuthloc;
  uint8_t gpio1 = 0;
  uint8_t gpio2 = 0;
  uint8_t gpio3 = 0;
  uint8_t gpio4 = 0;
  uint8_t systemstatus = 0;
  String data;
};

struct DataOutcome { 				// Data structure from UART to PC
  char move;
  uint8_t speed;
  char value;
  uint16_t lcurr;
  uint16_t rcurr;
  float accx;
  float accy;
  float accz;
  float gyrox;
  float gyroy;
  float gyroz;
  float magx;
  float magy;
  float magz;
  String lan;
  String lon;
  float vbat;
  uint8_t systemstatus = 0;
  uint16_t extid = 0;
  uint8_t extstatus = 0;
};

struct MainParameters {        // Data structure of platform parameters
  uint8_t systemstatus = 0;
  uint16_t extid = 0;
  uint8_t extstatus = 0;

  String GPSTimestamp ="";
  String GPSLatitude = "0.000000";
  String GPSLongitude = "0.000000";
};

class Platform {   // class Platform
  public:
    DataIncome controlDataIn;
    DataOutcome controlDataOut;
    MainParameters mainParameters;

    //GPIO mode
    uint8_t GPIO1 = 0;
    uint8_t GPIO2 = 0;
    uint8_t GPIO3 = 0;
    uint8_t GPIO4 = 0;


    //MPU6050 sensor
    volatile float AccX, AccY, AccZ;
    volatile float GyroX, GyroY, GyroZ;
    volatile float AccErrorX, AccErrorY, GyroErrorX, GyroErrorY, GyroErrorZ;
    volatile float Temperature;
    volatile int MPU_Calib_Counter = 0;
    volatile float AccDevider, GyroDevider = 0;

    Platform();
    void begin(String name, String key);

    //Movements section
    void makeMove(uint8_t direction, uint8_t speed, uint8_t acceleration);
    void brake(uint8_t mode);

    //Telemetry section
    bool initUARTControlData(Platform platform, int baudrate);
    bool initUARTControlData(Platform platform);
    void getUARTControlData(void);
    void sendUARTControlData(String outgoingDataString);
    bool getGPSData(Stream* _serial);
    void initMPU();
    void getMPUData();

    //MasterLink section
    void GPIOSetup(uint8_t GPIO_1, uint8_t GPIO_2, uint8_t GPIO_3, uint8_t GPIO_4);

    //Another useful functions
    void startBench();
    void stopBench(Stream* _serial);
    float convertRawCoordinatesToDegrees(float RawDegrees);
    void I2Cread(uint8_t Address, uint8_t Register, uint8_t Nbytes, uint8_t* Data);
    void I2CwriteByte(uint8_t Address, uint8_t Register, uint8_t Data);

  private:
    String PlatformKey = "";                 // Platform's private key
    String PlatformName = "";                // Platform's name

    //Move UART command section
    String stringUARTCommand = "";           // Variable of collection of accepted command characters per line
    volatile bool startedUARTCommandRecieve; // Variable odf uart command data recieve begin
    volatile uint8_t indexUARTCommand = 0;   // Index of accepted command mode argument

    //Load UART command section
    String stringUARTLoad = "";              // Variable of collecting accepted platform load symbols per string
    volatile bool startedUARTLoadRecieve;    // Platform load data start variable by uart
};
