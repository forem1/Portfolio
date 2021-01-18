unit Graphics;

interface

uses GraphABC;

var
  XCoord: integer := 270;
  YCoord: integer := 40;
  Size: integer := 30;
  StartSound:= new System.Media.SoundPlayer('start.wav');
  DieSound:= new System.Media.SoundPlayer('die.wav');
  LevelSound:= new System.Media.SoundPlayer('level.wav');

procedure DrawAnimal();
procedure DrawDie();
procedure DrawLevels(var Health, Hungry, Happy, Age: integer);

implementation

procedure DrawAnimal;
begin
  StartSound.Play;
  {1}
  rectangle(XCoord + (Size * 5), YCoord, XCoord + Size + (Size * 5), YCoord + Size);
  floodfill(XCoord + 1 + (Size * 5), YCoord + 1, clblack);
  rectangle(XCoord + (Size * 6), YCoord, XCoord + Size + (Size * 6), YCoord + Size);
  floodfill(XCoord + 1 + (Size * 6), YCoord + 1, clblack);
  rectangle(XCoord + (Size * 7), YCoord, XCoord + Size + (Size * 7), YCoord + Size);
  floodfill(XCoord + 1 + (Size * 7), YCoord + 1, clblack);
  rectangle(XCoord + (Size * 8), YCoord, XCoord + Size + (Size * 8), YCoord + Size);
  floodfill(XCoord + 1 + (Size * 8), YCoord + 1, clblack);
  rectangle(XCoord + (Size * 9), YCoord, XCoord + Size + (Size * 9), YCoord + Size);
  floodfill(XCoord + 1 + (Size * 9), YCoord + 1, clblack);
  rectangle(XCoord + (Size * 10), YCoord, XCoord + Size + (Size * 10), YCoord + Size);
  floodfill(XCoord + 1 + (Size * 10), YCoord + 1, clblack);
  {2}
  rectangle(XCoord + (Size * 4), YCoord + (Size * 1), XCoord + Size + (Size * 4), YCoord + Size + (Size * 1));
  floodfill(XCoord + 1 + (Size * 4), YCoord + 1 + (Size * 1), clblack);
  rectangle(XCoord + (Size * 9), YCoord + (Size * 1), XCoord + Size + (Size * 9), YCoord + Size + (Size * 1));
  floodfill(XCoord + 1 + (Size * 9), YCoord + 1 + (Size * 1), clblack);
  {3}
  rectangle(XCoord + (Size * 3), YCoord + (Size * 2), XCoord + Size + (Size * 3), YCoord + Size + (Size * 2));
  floodfill(XCoord + 1 + (Size * 3), YCoord + 1 + (Size * 2), clblack);
  rectangle(XCoord + (Size * 6), YCoord + (Size * 2), XCoord + Size + (Size * 6), YCoord + Size + (Size * 2));
  floodfill(XCoord + 1 + (Size * 6), YCoord + 1 + (Size * 2), clblack);
  rectangle(XCoord + (Size * 7), YCoord + (Size * 2), XCoord + Size + (Size * 7), YCoord + Size + (Size * 2));
  floodfill(XCoord + 1 + (Size * 7), YCoord + 1 + (Size * 2), clblack);
  rectangle(XCoord + (Size * 8), YCoord + (Size * 2), XCoord + Size + (Size * 8), YCoord + Size + (Size * 2));
  floodfill(XCoord + 1 + (Size * 8), YCoord + 1 + (Size * 2), clblack);
  rectangle(XCoord + (Size * 9), YCoord + (Size * 2), XCoord + Size + (Size * 9), YCoord + Size + (Size * 2));
  floodfill(XCoord + 1 + (Size * 9), YCoord + 1 + (Size * 2), clblack);
  rectangle(XCoord + (Size * 10), YCoord + (Size * 2), XCoord + Size + (Size * 10), YCoord + Size + (Size * 2));
  floodfill(XCoord + 1 + (Size * 10), YCoord + 1 + (Size * 2), clblack);
  rectangle(XCoord + (Size * 11), YCoord + (Size * 2), XCoord + Size + (Size * 11), YCoord + Size + (Size * 2));
  floodfill(XCoord + 1 + (Size * 11), YCoord + 1 + (Size * 2), clblack);
  {4}
  rectangle(XCoord + (Size * 2), YCoord + (Size * 3), XCoord + Size + (Size * 2), YCoord + Size + (Size * 3));
  floodfill(XCoord + 1 + (Size * 2), YCoord + 1 + (Size * 3), clblack);
  rectangle(XCoord + (Size * 4), YCoord + (Size * 3), XCoord + Size + (Size * 4), YCoord + Size + (Size * 3));
  floodfill(XCoord + 1 + (Size * 4), YCoord + 1 + (Size * 3), clblack);
  rectangle(XCoord + (Size * 5), YCoord + (Size * 3), XCoord + Size + (Size * 5), YCoord + Size + (Size * 3));
  floodfill(XCoord + 1 + (Size * 5), YCoord + 1 + (Size * 3), clblack);
  rectangle(XCoord + (Size * 10), YCoord + (Size * 3), XCoord + Size + (Size * 10), YCoord + Size + (Size * 3));
  floodfill(XCoord + 1 + (Size * 10), YCoord + 1 + (Size * 3), clblack);
  {5}
  rectangle(XCoord + (Size * 1), YCoord + (Size * 4), XCoord + Size + (Size * 1), YCoord + Size + (Size * 4));
  floodfill(XCoord + 1 + (Size * 1), YCoord + 1 + (Size * 4), clblack);
  rectangle(XCoord + (Size * 7), YCoord + (Size * 4), XCoord + Size + (Size * 7), YCoord + Size + (Size * 4));
  floodfill(XCoord + 1 + (Size * 7), YCoord + 1 + (Size * 4), clblack);
  rectangle(XCoord + (Size * 8), YCoord + (Size * 4), XCoord + Size + (Size * 8), YCoord + Size + (Size * 4));
  floodfill(XCoord + 1 + (Size * 8), YCoord + 1 + (Size * 4), clblack);
  rectangle(XCoord + (Size * 9), YCoord + (Size * 4), XCoord + Size + (Size * 9), YCoord + Size + (Size * 4));
  floodfill(XCoord + 1 + (Size * 9), YCoord + 1 + (Size * 4), clblack);
  rectangle(XCoord + (Size * 12), YCoord + (Size * 4), XCoord + Size + (Size * 12), YCoord + Size + (Size * 4));
  floodfill(XCoord + 1 + (Size * 12), YCoord + 1 + (Size * 4), clblack);
  rectangle(XCoord + (Size * 13), YCoord + (Size * 4), XCoord + Size + (Size * 13), YCoord + Size + (Size * 4));
  floodfill(XCoord + 1 + (Size * 13), YCoord + 1 + (Size * 4), clblack);
  {6}
  rectangle(XCoord + (Size * 1), YCoord + (Size * 5), XCoord + Size + (Size * 1), YCoord + Size + (Size * 5));
  floodfill(XCoord + 1 + (Size * 1), YCoord + 1 + (Size * 5), clblack);
  rectangle(XCoord + (Size * 3), YCoord + (Size * 5), XCoord + Size + (Size * 3), YCoord + Size + (Size * 5));
  floodfill(XCoord + 1 + (Size * 3), YCoord + 1 + (Size * 5), clblack);
  rectangle(XCoord + (Size * 6), YCoord + (Size * 5), XCoord + Size + (Size * 6), YCoord + Size + (Size * 5));
  floodfill(XCoord + 1 + (Size * 6), YCoord + 1 + (Size * 5), clblack);
  rectangle(XCoord + (Size * 7), YCoord + (Size * 5), XCoord + Size + (Size * 7), YCoord + Size + (Size * 5));
  floodfill(XCoord + 1 + (Size * 7), YCoord + 1 + (Size * 5), clblack);
  rectangle(XCoord + (Size * 8), YCoord + (Size * 5), XCoord + Size + (Size * 8), YCoord + Size + (Size * 5));
  floodfill(XCoord + 1 + (Size * 8), YCoord + 1 + (Size * 5), clblack);
  rectangle(XCoord + (Size * 9), YCoord + (Size * 5), XCoord + Size + (Size * 9), YCoord + Size + (Size * 5));
  floodfill(XCoord + 1 + (Size * 9), YCoord + 1 + (Size * 5), clblack);
  rectangle(XCoord + (Size * 10), YCoord + (Size * 5), XCoord + Size + (Size * 10), YCoord + Size + (Size * 5));
  floodfill(XCoord + 1 + (Size * 10), YCoord + 1 + (Size * 5), clblack);
  rectangle(XCoord + (Size * 11), YCoord + (Size * 5), XCoord + Size + (Size * 11), YCoord + Size + (Size * 5));
  floodfill(XCoord + 1 + (Size * 11), YCoord + 1 + (Size * 5), clblack);
  rectangle(XCoord + (Size * 14), YCoord + (Size * 5), XCoord + Size + (Size * 14), YCoord + Size + (Size * 5));
  floodfill(XCoord + 1 + (Size * 14), YCoord + 1 + (Size * 5), clblack);
  {7}
  rectangle(XCoord + (Size * 1), YCoord + (Size * 6), XCoord + Size + (Size * 1), YCoord + Size + (Size * 6));
  floodfill(XCoord + 1 + (Size * 1), YCoord + 1 + (Size * 6), clblack);
  rectangle(XCoord + (Size * 6), YCoord + (Size * 6), XCoord + Size + (Size * 6), YCoord + Size + (Size * 6));
  floodfill(XCoord + 1 + (Size * 6), YCoord + 1 + (Size * 6), clblack);
  rectangle(XCoord + (Size * 12), YCoord + (Size * 6), XCoord + Size + (Size * 12), YCoord + Size + (Size * 6));
  floodfill(XCoord + 1 + (Size * 12), YCoord + 1 + (Size * 6), clblack);
  rectangle(XCoord + (Size * 14), YCoord + (Size * 6), XCoord + Size + (Size * 14), YCoord + Size + (Size * 6));
  floodfill(XCoord + 1 + (Size * 14), YCoord + 1 + (Size * 6), clblack);
  {8}
  rectangle(XCoord + (Size * 1), YCoord + (Size * 7), XCoord + Size + (Size * 1), YCoord + Size + (Size * 7));
  floodfill(XCoord + 1 + (Size * 1), YCoord + 1 + (Size * 7), clblack);
  rectangle(XCoord + (Size * 2), YCoord + (Size * 7), XCoord + Size + (Size * 2), YCoord + Size + (Size * 7));
  floodfill(XCoord + 1 + (Size * 2), YCoord + 1 + (Size * 7), clblack);
  rectangle(XCoord + (Size * 13), YCoord + (Size * 7), XCoord + Size + (Size * 13), YCoord + Size + (Size * 7));
  floodfill(XCoord + 1 + (Size * 13), YCoord + 1 + (Size * 7), clblack);
  {9}
  rectangle(XCoord + (Size * 2), YCoord + (Size * 8), XCoord + Size + (Size * 2), YCoord + Size + (Size * 8));
  floodfill(XCoord + 1 + (Size * 2), YCoord + 1 + (Size * 8), clblack);
  rectangle(XCoord + (Size * 7), YCoord + (Size * 8), XCoord + Size + (Size * 7), YCoord + Size + (Size * 8));
  floodfill(XCoord + 1 + (Size * 7), YCoord + 1 + (Size * 8), clblack);
  rectangle(XCoord + (Size * 9), YCoord + (Size * 8), XCoord + Size + (Size * 9), YCoord + Size + (Size * 8));
  floodfill(XCoord + 1 + (Size * 9), YCoord + 1 + (Size * 8), clblack);
  rectangle(XCoord + (Size * 10), YCoord + (Size * 8), XCoord + Size + (Size * 10), YCoord + Size + (Size * 8));
  floodfill(XCoord + 1 + (Size * 10), YCoord + 1 + (Size * 8), clblack);
  rectangle(XCoord + (Size * 13), YCoord + (Size * 8), XCoord + Size + (Size * 13), YCoord + Size + (Size * 8));
  floodfill(XCoord + 1 + (Size * 13), YCoord + 1 + (Size * 8), clblack);
  {10}
  rectangle(XCoord + (Size * 2), YCoord + (Size * 9), XCoord + Size + (Size * 2), YCoord + Size + (Size * 9));
  floodfill(XCoord + 1 + (Size * 2), YCoord + 1 + (Size * 9), clblack);
  rectangle(XCoord + (Size * 6), YCoord + (Size * 9), XCoord + Size + (Size * 6), YCoord + Size + (Size * 9));
  floodfill(XCoord + 1 + (Size * 6), YCoord + 1 + (Size * 9), clblack);
  rectangle(XCoord + (Size * 7), YCoord + (Size * 9), XCoord + Size + (Size * 7), YCoord + Size + (Size * 9));
  floodfill(XCoord + 1 + (Size * 7), YCoord + 1 + (Size * 9), clblack);
  rectangle(XCoord + (Size * 8), YCoord + (Size * 9), XCoord + Size + (Size * 8), YCoord + Size + (Size * 9));
  floodfill(XCoord + 1 + (Size * 8), YCoord + 1 + (Size * 9), clblack);
  rectangle(XCoord + (Size * 12), YCoord + (Size * 9), XCoord + Size + (Size * 12), YCoord + Size + (Size * 9));
  floodfill(XCoord + 1 + (Size * 12), YCoord + 1 + (Size * 9), clblack);
  {11}
  rectangle(XCoord + (Size * 2), YCoord + (Size * 10), XCoord + Size + (Size * 2), YCoord + Size + (Size * 10));
  floodfill(XCoord + 1 + (Size * 2), YCoord + 1 + (Size * 10), clblack);
  rectangle(XCoord + (Size * 3), YCoord + (Size * 10), XCoord + Size + (Size * 3), YCoord + Size + (Size * 10));
  floodfill(XCoord + 1 + (Size * 3), YCoord + 1 + (Size * 10), clblack);
  rectangle(XCoord + (Size * 4), YCoord + (Size * 10), XCoord + Size + (Size * 4), YCoord + Size + (Size * 10));
  floodfill(XCoord + 1 + (Size * 4), YCoord + 1 + (Size * 10), clblack);
  rectangle(XCoord + (Size * 5), YCoord + (Size * 10), XCoord + Size + (Size * 5), YCoord + Size + (Size * 10));
  floodfill(XCoord + 1 + (Size * 5), YCoord + 1 + (Size * 10), clblack);
  rectangle(XCoord + (Size * 8), YCoord + (Size * 10), XCoord + Size + (Size * 8), YCoord + Size + (Size * 10));
  floodfill(XCoord + 1 + (Size * 8), YCoord + 1 + (Size * 10), clblack);
  rectangle(XCoord + (Size * 9), YCoord + (Size * 10), XCoord + Size + (Size * 9), YCoord + Size + (Size * 10));
  floodfill(XCoord + 1 + (Size * 9), YCoord + 1 + (Size * 10), clblack);
  rectangle(XCoord + (Size * 10), YCoord + (Size * 10), XCoord + Size + (Size * 10), YCoord + Size + (Size * 10));
  floodfill(XCoord + 1 + (Size * 10), YCoord + 1 + (Size * 10), clblack);
  rectangle(XCoord + (Size * 11), YCoord + (Size * 10), XCoord + Size + (Size * 11), YCoord + Size + (Size * 10));
  floodfill(XCoord + 1 + (Size * 11), YCoord + 1 + (Size * 10), clblack);
end;{конец процедуры DrawAnimal}

procedure DrawDie;
begin
  DieSound.Play;
  {1}
  rectangle(XCoord + (Size * 1), YCoord, XCoord + Size + (Size * 1), YCoord + Size);
  floodfill(XCoord + 1 + (Size * 1), YCoord + 1, clred);
  rectangle(XCoord + (Size * 10), YCoord, XCoord + Size + (Size * 10), YCoord + Size);
  floodfill(XCoord + 1 + (Size * 10), YCoord + 1, clred);
  {2}
  rectangle(XCoord + (Size * 2), YCoord + (Size * 1), XCoord + Size + (Size * 2), YCoord + Size + (Size * 1));
  floodfill(XCoord + 1 + (Size * 2), YCoord + 1 + (Size * 1), clred);
  rectangle(XCoord + (Size * 9), YCoord + (Size * 1), XCoord + Size + (Size * 9), YCoord + Size + (Size * 1));
  floodfill(XCoord + 1 + (Size * 9), YCoord + 1 + (Size * 1), clred);
  {3}
  rectangle(XCoord + (Size * 3), YCoord + (Size * 2), XCoord + Size + (Size * 3), YCoord + Size + (Size * 2));
  floodfill(XCoord + 1 + (Size * 3), YCoord + 1 + (Size * 2), clred);
  rectangle(XCoord + (Size * 8), YCoord + (Size * 2), XCoord + Size + (Size * 8), YCoord + Size + (Size * 2));
  floodfill(XCoord + 1 + (Size * 8), YCoord + 1 + (Size * 2), clred);
  {4}
  rectangle(XCoord + (Size * 4), YCoord + (Size * 3), XCoord + Size + (Size * 4), YCoord + Size + (Size * 3));
  floodfill(XCoord + 1 + (Size * 4), YCoord + 1 + (Size * 3), clred);
  rectangle(XCoord + (Size * 7), YCoord + (Size * 3), XCoord + Size + (Size * 7), YCoord + Size + (Size * 3));
  floodfill(XCoord + 1 + (Size * 7), YCoord + 1 + (Size * 3), clred);
  {5}
  rectangle(XCoord + (Size * 5), YCoord + (Size * 4), XCoord + Size + (Size * 5), YCoord + Size + (Size * 4));
  floodfill(XCoord + 1 + (Size * 5), YCoord + 1 + (Size * 4), clred);
  rectangle(XCoord + (Size * 6), YCoord + (Size * 4), XCoord + Size + (Size * 6), YCoord + Size + (Size * 4));
  floodfill(XCoord + 1 + (Size * 6), YCoord + 1 + (Size * 4), clred);
  {6}
  rectangle(XCoord + (Size * 6), YCoord + (Size * 5), XCoord + Size + (Size * 6), YCoord + Size + (Size * 5));
  floodfill(XCoord + 1 + (Size * 6), YCoord + 1 + (Size * 5), clred);
  rectangle(XCoord + (Size * 5), YCoord + (Size * 5), XCoord + Size + (Size * 5), YCoord + Size + (Size * 5));
  floodfill(XCoord + 1 + (Size * 5), YCoord + 1 + (Size * 5), clred);
  {7}
  rectangle(XCoord + (Size * 7), YCoord + (Size * 6), XCoord + Size + (Size * 7), YCoord + Size + (Size * 6));
  floodfill(XCoord + 1 + (Size * 7), YCoord + 1 + (Size * 6), clred);
  rectangle(XCoord + (Size * 4), YCoord + (Size * 6), XCoord + Size + (Size * 4), YCoord + Size + (Size * 6));
  floodfill(XCoord + 1 + (Size * 4), YCoord + 1 + (Size * 6), clred);
  {8}
  rectangle(XCoord + (Size * 8), YCoord + (Size * 7), XCoord + Size + (Size * 8), YCoord + Size + (Size * 7));
  floodfill(XCoord + 1 + (Size * 8), YCoord + 1 + (Size * 7), clred);
  rectangle(XCoord + (Size * 3), YCoord + (Size * 7), XCoord + Size + (Size * 3), YCoord + Size + (Size * 7));
  floodfill(XCoord + 1 + (Size * 3), YCoord + 1 + (Size * 7), clred);
  {9}
  rectangle(XCoord + (Size * 9), YCoord + (Size * 8), XCoord + Size + (Size * 9), YCoord + Size + (Size * 8));
  floodfill(XCoord + 1 + (Size * 9), YCoord + 1 + (Size * 8), clred);
  rectangle(XCoord + (Size * 2), YCoord + (Size * 8), XCoord + Size + (Size * 2), YCoord + Size + (Size * 8));
  floodfill(XCoord + 1 + (Size * 2), YCoord + 1 + (Size * 8), clred);
  {10}
  rectangle(XCoord + (Size * 10), YCoord + (Size * 9), XCoord + Size + (Size * 10), YCoord + Size + (Size * 9));
  floodfill(XCoord + 1 + (Size * 10), YCoord + 1 + (Size * 9), clred);
  rectangle(XCoord + (Size * 1), YCoord + (Size * 9), XCoord + Size + (Size * 1), YCoord + Size + (Size * 9));
  floodfill(XCoord + 1 + (Size * 1), YCoord + 1 + (Size * 9), clred);
end;{конец процедуры DrawDie}

procedure DrawLevels;
begin
  LevelSound.Play;
  var HealthTemp, HungryTemp, HappyTemp: integer;
  
  TextOut(XCoord + (Size * 1), YCoord + (Size * 13), 'Здоровье');
  rectangle(XCoord + (Size * 6), YCoord + (Size * 13), XCoord + Size + (Size * 6), YCoord + Size + (Size * 13));
  rectangle(XCoord + (Size * 7), YCoord + (Size * 13), XCoord + Size + (Size * 7), YCoord + Size + (Size * 13));
  rectangle(XCoord + (Size * 8), YCoord + (Size * 13), XCoord + Size + (Size * 8), YCoord + Size + (Size * 13));
  rectangle(XCoord + (Size * 9), YCoord + (Size * 13), XCoord + Size + (Size * 9), YCoord + Size + (Size * 13));
  rectangle(XCoord + (Size * 10), YCoord + (Size * 13), XCoord + Size + (Size * 10), YCoord + Size + (Size * 13));
  for HealthTemp := 1 to Health do
  begin
    floodfill(XCoord + 1 + (Size * (5 + HealthTemp)), YCoord + 1 + (Size * 13), clred);
  end;
  
  TextOut(XCoord + (Size * 1), YCoord + (Size * 15), 'Голод');
  rectangle(XCoord + (Size * 6), YCoord + (Size * 15), XCoord + Size + (Size * 6), YCoord + Size + (Size * 15));
  rectangle(XCoord + (Size * 7), YCoord + (Size * 15), XCoord + Size + (Size * 7), YCoord + Size + (Size * 15));
  rectangle(XCoord + (Size * 8), YCoord + (Size * 15), XCoord + Size + (Size * 8), YCoord + Size + (Size * 15));
  rectangle(XCoord + (Size * 9), YCoord + (Size * 15), XCoord + Size + (Size * 9), YCoord + Size + (Size * 15));
  rectangle(XCoord + (Size * 10), YCoord + (Size * 15), XCoord + Size + (Size * 10), YCoord + Size + (Size * 15));
  for HungryTemp := 1 to Hungry do 
  begin
    floodfill(XCoord + 1 + (Size * (5 + HungryTemp)), YCoord + 1 + (Size * 15), clblue);
  end;
  
  TextOut(XCoord + (Size * 1), YCoord + (Size * 17), 'Счастье');
  rectangle(XCoord + (Size * 6), YCoord + (Size * 17), XCoord + Size + (Size * 6), YCoord + Size + (Size * 17));
  rectangle(XCoord + (Size * 7), YCoord + (Size * 17), XCoord + Size + (Size * 7), YCoord + Size + (Size * 17));
  rectangle(XCoord + (Size * 8), YCoord + (Size * 17), XCoord + Size + (Size * 8), YCoord + Size + (Size * 17));
  rectangle(XCoord + (Size * 9), YCoord + (Size * 17), XCoord + Size + (Size * 9), YCoord + Size + (Size * 17));
  rectangle(XCoord + (Size * 10), YCoord + (Size * 17), XCoord + Size + (Size * 10), YCoord + Size + (Size * 17));
  for HappyTemp := 1 to Happy do
  begin
    floodfill(XCoord + 1 + (Size * (5 + HappyTemp)), YCoord + 1 + (Size * 17), clgreen);
  end;
  
  TextOut(XCoord + (Size * 1), YCoord + (Size * 19), 'Возраст');
  TextOut(XCoord + (Size * 8), YCoord + (Size * 19), Age);
end;

begin
  setwindowsize(1000, 800);
  SetWindowCaption('Simple tamagotchi');
  SetFontName('Arial');
  SetFontStyle(fsBoldItalic);
  SetFontSize(16);
end. {конец модуля Graphics }