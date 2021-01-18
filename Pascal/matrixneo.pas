uses
  crt;

var
  first: string;
  second: string;
  third: string;
  firstTemp: string;
  secondTemp: string;
  thirdTemp: string;
  KnockSound := new System.Media.SoundPlayer('knock.wav');

begin
  first := 'Wake up, Neo.';
  second := 'Follow the white rabbit...';
  third := 'Knock knock';
  
  textbackground(0);
  clrscr;
  textcolor(green);
   
  gotoxy(50, 13);
  
  for var i: integer := 1 to Length(first) do
  begin
    firstTemp := firstTemp + first[i];
    clrscr;
    gotoxy(50 - i, 13);
    write(firstTemp);
    delay(10);
  end;
  
  gotoxy(50, 15);
  delay(1000);
  
  for var i: integer := 1 to Length(second) do
  begin
    write(second[i]);
    delay(100);
  end;
  
  delay(3000);
  
  clrscr;
  gotoxy(50, 18);
  write(third);
  
  delay(1000);
  KnockSound.Play;
  readln
end.

