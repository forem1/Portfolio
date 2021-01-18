var
  a, b, S, P: real;

begin
  writeln('Введите стороны:');
  readln(a, b);
  S := a * b;
  P := 2 * (a + b);
  writeln('Результат:');
  writeln('S = ', S:0:2);
  writeln('P = ', P:0:2);
end.