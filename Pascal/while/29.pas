var
  K, n: integer;
  e, A1, A2, AK: real;

begin
  write('e = ');
  readln(e);
  A1 := 1;
  A2 := 2;
  AK := (A1 + 2 * A2) / 3;
  K := 3;
  n := trunc(-ln(e) / ln(10)) + 2;
  
  while (abs(AK - A2) >= e) do
  begin
    inc(K); 
    A1 := A2; 
    A2 := AK; 
    AK := (A1 + 2 * A2) / 3
  end;
  writeln('K = ', K);
  writeln('A', K - 1, ' = ', A2:0:n, ',  A', K, ' = ', AK:0:n);
  readln
end.