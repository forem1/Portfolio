var
  d, m: integer;

begin
  write('день:');
  readln(d);
  write('месяц:');
  readln(m);
  
  if (d <0) or (d>31) or ((m = 2) and (d>29)) then WriteLn('неправильно введен день')
  else
  begin
  
  case m of
    1: if(d >= 20) then write('Водолей') else write('Козерог');
    2: if(d >= 19) then write('Рыбы') else write('Водолей');
    3: if(d >= 21) then write('Овен') else write('Рыбы');
    4: if(d >= 20) then write('Телец') else write('Овен');
    5: if(d >= 21) then write('Близнецы') else write('Телец');
    6: if(d >= 22) then write('Рак') else write('Близнецы');
    7: if(d >= 23) then write('Лев') else write('Рак');
    8: if(d >= 23) then write('Дева') else write('Лев');
    9: if(d >= 23) then write('Весы') else write('Дева');
    10: if(d >= 23) then write('Скорпион') else write('Весы');
    11: if(d >= 23) then write('Стрелец') else write('Скорпион');
    12: if(d >= 22) then write('Козерог') else write('Стрелец');
  Else
    WriteLn('неправильно введен месяц');
  end;
  end;
end.