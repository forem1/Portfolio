var
  S, S0: string;
  pos1: integer;

begin
  Write('S:');
  Readln(S);
  Write('S0:');
  Readln(S0);
  
  pos1 := pos(S0, S);
  
  while (pos1 <> 0) do
  begin
    delete(S, pos1, length(S0));
    pos1 := pos(S0, S);
  end;
  Writeln(S);
end.