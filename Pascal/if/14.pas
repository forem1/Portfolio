program if14;

var
  A, B, C: Real;

begin
  Write('первое число: ');
  Readln(A);
  
  Write('второе число: ');
  Readln(B);
  
  Write('третье число: ');
  Readln(C);
  
  if A < B then
    if B < C then
    begin
      Writeln('Наименьшее число: ', A);
      Writeln('Наибольшее число: ', C);
    end
    else if (A < C) then
    begin
      Writeln('Наименьшее число: ', A);
      Writeln('Наибольшее число: ', B);
    end
      else
    begin
      Writeln('Наименьшее число: ', C);
      Writeln('Наибольшее число: ', B);
    end
  else
  
  if B > C then
  begin
    Writeln('Наименьшее число: ', C);
    Writeln('Наибольшее число: ', A);
  end
  else if A < C then
  begin
    Writeln('Наименьшее число: ', B);
    Writeln('Наибольшее число: ', C);
  end
  else
  begin
    Writeln('Наименьшее число: ', B);
    Writeln('Наибольшее число: ', A);
  end;
  if (A=B) or (B=C) or (C=A) then writeln('числа равны');
end.