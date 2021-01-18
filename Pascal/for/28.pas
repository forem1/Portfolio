var
  X, C, pow, Temp1, Temp2: Real;
  N, i: Integer;

begin
  Write('X: ');
  Readln(X);
  Write('N: ');
  Readln(N);
  
  if N < 0 then Write('error')
  else
  begin
    
    C := 1;
    pow := 1;
    Temp1 := 1;
    Temp2 := 1;
    
    for i := 1 to N do
    begin
      Temp1 := Temp1 * (2 * i - 3);
      Temp2 := Temp2 * (2 * i);
      pow := pow * X * (-1);
      C := C + Temp1 * Pow / temp2;
    end;
    Writeln(C);
  end
end.