uses crt;

var i:integer;

begin
    for i:=1 to 24 do begin
        NoSound;
        textbackground(i);
        gotoxy(1, i);
        write(i);
        Sound(100*i);
        delay(100);
    end;
    gotoxy(15,24);
    textbackground(white);
    textcolor(blue);
    write('MESH TEAM');
end.