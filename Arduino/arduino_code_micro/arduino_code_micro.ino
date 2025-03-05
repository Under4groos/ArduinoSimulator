#include "Keyboard.h"
#include <Mouse.h>
#include <ArduinoBoardManager.h>
ArduinoBoardManager arduino = ArduinoBoardManager();
void setup() {

  Serial.begin(300);
  Keyboard.begin();
  Mouse.begin();
  DebugMode();
}

void DebugMode() {
  unsigned long M = 1000000;
  unsigned int k = 1000;
  Serial.print("Board is compatible with Arduino ");
  Serial.println(arduino.BOARD_NAME);
  Serial.println();

  // the Arduino SDK version
  Serial.print("SDK Version is: ");
  Serial.println(ArduinoBoardManager::SDK_VERSION);
  Serial.println();

  // The processor features (RAM, speed, etc)
  Serial.print("This ");
  Serial.print(arduino.BOARD_NAME);
  Serial.print(" is an ");
  Serial.print(ArduinoBoardManager::NUM_BITS);
  Serial.print("-bit, ");
  Serial.print(ArduinoBoardManager::MAX_MHZ / M);
  Serial.print("Mhz processor with ");
  Serial.print(ArduinoBoardManager::SRAM_SIZE / k);
  Serial.print("k of SRAM and ");
  Serial.print(ArduinoBoardManager::FLASH_SIZE / k);
  Serial.println("k of flash.");
  Serial.println();

  // Board features (multiple serial ports on Mega, for example)
  if (arduino.featureExists(ArduinoBoardManager::FEATURE_MULTIPLE_SERIAL)) {
    Serial.println("Your board supports multiple serial connections");
  } else {
    Serial.println("Your board only supports one serial connection");
  }

  if (arduino.featureExists(ArduinoBoardManager::FEATURE_ANALOG_OUT)) {
    Serial.println("Your board supports analog out");
  }
  if (arduino.featureExists(ArduinoBoardManager::FEATURE_BLUETOOTH_4)) {
    Serial.println("Your board supports bluetooth 4");
  }
}
int readInt() {
  return Serial.readString().toInt();
}
// all
int mode;
int delay_p;

// mouse
int x;
int y;
int wheel;
int mouse_button;
int mouse_status;

void msg(String desc, int status) {
  Serial.print(desc + ": ");
  Serial.print(status);
  Serial.println("");
}

void loop() {

  if (Serial.available()) {
    mode = Serial.parseInt();
    delay_p = Serial.parseInt();
    msg("mode:", mode);
    msg("delay_p", delay_p);
    switch (mode) {
      case 0:
        {
          x = Serial.parseInt();
          y = Serial.parseInt();
          wheel = Serial.parseInt();
          Mouse.move(x, y, wheel);
          break;
        }


      case 1:
        mouse_button = Serial.parseInt();
        mouse_status = Serial.parseInt();
        msg("mouse_button", mouse_button);
        msg("mouse_status", mouse_status);
        if (mouse_status == 0) {
          Mouse.click(mouse_button);
          return;
        } else if (mouse_status == 1) {
          Mouse.press(mouse_button);
          return;
        } else if (mouse_status == 2) {
          Mouse.release(mouse_button);
          return;
        }
        break;
      case 3:
        break;
    }
    delay(delay_p);
  }
}
