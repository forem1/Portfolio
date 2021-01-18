var
  A, B, i, i2: Integer;

begin
  Write('A: ');
  Readln(A);
  Write('B: ');
  Readln(B);
  
  if A > B then Write('error');
  begin
    for i := 0 to B - A do
      for i2 := 0 to i do Writeln(A + i);
  end
end.