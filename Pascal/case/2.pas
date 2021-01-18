var
  k: Integer;

begin
  ReadLn(k); 
  case k Of
    1: WriteLn('плохо');
    2: WriteLn('неудовлетворительно');
    3: WriteLn('удовлетворительно');
    4: WriteLn('хорошо');
    5: WriteLn('отлично')
  Else
    WriteLn('нет оценки');
  End;
end.