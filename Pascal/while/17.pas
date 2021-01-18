var
  N: integer;

begin
  readln(N);
  writeln('Цифры числа (справа налево):');
  while N > 0 do
  begin
    write(' ', N mod 10);
    N := N div 10
  end;
end.