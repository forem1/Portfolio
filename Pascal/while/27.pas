var
  N, A1, A2, K: integer;

begin
  write('число ');
  readln(N);
  A1 := 1;
  A2 := 1; K := 2;
  
  while (N > A2) do
  begin
    A2 := A1 + A2; 
    A1 := A2 - A1;
    inc(K)
  end;
  
  if N = A2 then writeln('номер числа', K)
  else writeln(' ', N, ' не число фибоначчи');
end.