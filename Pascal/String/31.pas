var
  S, s0: string;
  C: Char;

begin
  Write('S:');
  Readln(S);
  Write('S0:');
  Readln(S0);
  
  writeln(pos(S0, S) > 0);
end.