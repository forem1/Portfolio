var
  a, b: array[1..100] of Integer;
  N, k, k2: Integer;


begin
  Write('введите N: ');
  Readln(N);
  
  Writeln('введите A: ');
  for k := 1 to N do
  begin
    write(k, ' :');
    readln(a[k]);
  end;
  
  
  k2 := 0;
  K := 1;
  while(k <= N) do //перебираем пользовательский ввод
  begin
    inc(k2);
    b[k2] := a[k];
    k := k + 2;
  end;
  
  K := 2;
  
  while(k <= N) do
  begin
    inc(k2);
    b[k2] := a[k];
    k := k + 2;
  end;
  writeln(k2, N);
  
  Writeln('B(', k2, '):');
  for k := 1 to N do writeln(k, ' :', b[k]);
end.