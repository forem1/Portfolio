var
  x: Integer;

begin
  Write('Введите число: ');
  Readln(x);
  if x > 0 then x := x + 1;
  if x < 0 then x := x - 2;
  if x = 0 then x := 10;
  writeln(x);
end.