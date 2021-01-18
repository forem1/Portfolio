uses GraphABC, Timers, Main, Graphics;

var
  HungryPressCount, HealthPressCount: integer;
  HappyPressCount: String;
  TimeDifferent: longint;
  EggSound := new System.Media.SoundPlayer('egg.wav');
  MaT, HeT, HuT, HaT  : Timer;

//---------------------процедуры таймеров параметров жизнедеяятельности-----------------------
procedure MainTimer;
begin
  DrawLevels(Health, Hungry, Happy, Age);
  if (Hungry <= 0) or (Health <= 0) then begin
    Die := 1;
    DrawDie();
  end;
end;

procedure HealthTimer;
begin
  dec(health);
end;

procedure HungryTimer;
begin
  dec(hungry);
end;

procedure HappyTimer;
begin
  dec(happy);
end;
//---------------------процедуры таймеров параметров жизнедеяятельности-----------------------

procedure KeyPressing(key: integer);
begin
  case key of
    VK_E: 
      begin
        if (HungryPressCount = 10) and (Hungry < 5) then begin
          inc(Hungry);
          DrawLevels(Health, Hungry, Happy, Age);
          //writeln(Hungry);
          HungryPressCount := 0;
        end
        else inc(HungryPressCount);
      end;
    VK_H: 
      if (HealthPressCount = 50) and (Health < 5) then begin
        inc(Health);
        DrawLevels(Health, Hungry, Happy, Age);
        writeln(Hungry);
        HealthPressCount := 0;
      end
      else inc(HealthPressCount);
    VK_A: HappyPressCount := HappyPressCount + '1';
    VK_S: HappyPressCount := HappyPressCount + '2';
    VK_D: HappyPressCount := HappyPressCount + '3';
    VK_F: HappyPressCount := HappyPressCount + '4';
    VK_G: 
      begin
        HappyPressCount := HappyPressCount + '5';
        if (HappyPressCount = '12345') and (Hungry < 5) then begin
          inc(Happy);
          DrawLevels(Health, Hungry, Happy, Age);
        end
        else HappyPressCount := '';
      end;
    VK_N: 
      begin
        Writeln('New Game');
        Health := 5;
        Hungry := 5;
        Happy := 5;
        Age := 1;
        Time := GetTime();
        Die := 0;
        WriteSettings();
      end;
    VK_Enter:
      begin
        MaT.Stop;
        HeT.Stop;
        HuT.Stop;
        HaT.Stop;
        EggSound.Play;
        Sleep(8300);
        while true do
        begin
          floodfill(1, 1, clred);
          sleep(500);
          floodfill(1, 1, clgreen);
          sleep(500);
          floodfill(1, 1, clblue);
          sleep(500);
          floodfill(1, 1, clyellow);
          sleep(500);
          floodfill(1, 1, clpink);
          sleep(500);
        end;
      end;
  end;
end;

procedure CloseWindow();
begin
  WriteSettings();
end;

begin
  //debug data
    //Health := 5;
    //Hungry := 5;
    //Happy := 5;
    //Age := 1;
    //Time := 2312441;
    //Die := 0;
    //DrawAnimal();
    //sleep(2000);
    //DrawDie();
    //DrawLevels(Health, Hungry, Happy, Age);
    //WriteSettings(Health, Hungry, Happy, Time, Age, Die);
    //ReadSettings();
    //writeln(Health);
    //writeln(Hungry);
    //writeln(Happy);
    //writeln(Time);
    //writeln(Die);
    //debug data
      
  //---------start main--------
  CenterWindow();
  
  ReadSettings();
  
  TimeDifferent := GetTime() - Time;
  //writeln(TimeDifferent);
  
  Health := Health - (TimeDifferent div 120);
  Hungry := Hungry - (TimeDifferent div 60);
  Happy := Happy - (TimeDifferent div 30);
  Age := Age + (TimeDifferent div 600);
  
  DrawAnimal();
  DrawLevels(Health, Hungry, Happy, Age);
  
  if Die = 1 then begin
    DrawDie();
  end
  else begin
    MaT := new Timer(10000, MainTimer);
    HeT := new Timer(120000, HealthTimer);
    HuT := new Timer(60000, HungryTimer);
    HaT := new Timer(30000, HappyTimer);
    MaT.Start;
    HeT.Start;
    HuT.Start;
    HaT.Start;
  end;
  
  OnKeyDown := KeyPressing;
  onClose := CloseWindow;
end.