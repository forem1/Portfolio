unit Main;

interface

uses System, PABCSystem;

var
  Health, Hungry, Happy, Age, Die: integer;
  Time: longint;
  SettingsFile: Text;

function GetTime(): longint;
procedure WriteSettings();
procedure ReadSettings();
implementation

function GetTime(): longint;
begin
  var d: DateTime := DateTime.Now;
  //Writeln(d.Year);
  //Writeln(d.Month);
  //Writeln(d.Day);
  //Writeln(d.Hour);
  //Writeln(d.Minute);
  Result := ((d.Year - 1970) * 31556926) + (d.Month * 2629743) + (d.Day * 86400) + (d.Hour * 3600) + (d.Minute * 60)+ d.Second;
end;{конец процедуры GetTime }

procedure WriteSettings();
begin
  assign(SettingsFile, 'Settings.dat');
  rewrite(SettingsFile);
  write(SettingsFile, Health, ' ', Hungry, ' ', Happy, ' ', Age, ' ', Die, ' ', Time);
  close(SettingsFile);
end;

procedure ReadSettings();
begin
  if FileExists('Settings.dat') then begin
    assign(SettingsFile, 'Settings.dat');
    reset(SettingsFile);
    while not eof(SettingsFile) do 
    begin
      read(SettingsFile, Health, Hungry, Happy, Age, Die, Time);
    end;
    close(SettingsFile);
    //writeln(Time);
  end
  else begin
    Health := 5;
    Hungry := 5;
    Happy := 5;
    Age := 1;
    Time := GetTime();
    Die := 0;
    WriteSettings();
  end;
end;

end. {конец модуля Main }