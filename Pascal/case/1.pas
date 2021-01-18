var
  d: Integer;

begin
  ReadLn(d); 
  case d Of
    1: WriteLn('понедельник');
    2: WriteLn('вторник');
    3: WriteLn('среда');
    4: WriteLn('четверг');
    5: WriteLn('пятница');
    6: WriteLn('суббота');
    7: WriteLn('воскресенье')
  Else
    WriteLn('нет дня недели');
  End;
end.