//unit Chunk;
uses Graph3D;
//uses World;
 
type
    ChunkClass = class
        faceCount: integer;
        chunkSize: byte;
        chunkX: integer;
        chunkY: integer;
        chunkZ: integer;
        
        procedure Cube(p1, p2, p3, p4: Point3D; m: GColor);
        begin
            Triangle(p1, p2, p3, m);
            Triangle(p3, p4, p1, m);
            
            faceCount += 1;
        end;
        
        
        procedure CubeT(x: integer; y: integer; z: integer; block: byte);
        begin
            var p1 := P3D(x, y, z + 1);
            var p2 := P3D(x + 1, y, z + 1);
            var p3 := P3D(x + 1, y, z );
            var p4 := P3D(x, y, z );
            Cube(p1, p2, p3, p4, Colors.Green);
        end;
        
        procedure CubeN(x: integer; y: integer; z: integer; block: byte);
        begin
            var p1 := P3D(x + 1, y - 1, z + 1);
            var p2 := P3D(x + 1, y, z + 1);
            var p3 := P3D(x, y, z + 1);
            var p4 := P3D(x, y - 1, z + 1);
            Cube(p1, p2, p3, p4, Colors.Green);
        end;
        
        procedure CubeE(x: integer; y: integer; z: integer; block: byte);
        begin
            var p1 := P3D(x + 1, y - 1, z);
            var p2 := P3D(x + 1, y, z);
            var p3 := P3D(x + 1, y, z + 1);
            var p4 := P3D(x + 1, y - 1, z + 1);
            Cube(p1, p2, p3, p4, Colors.Green);
        end;
        
        procedure CubeS(x: integer; y: integer; z: integer; block: byte);
        begin
            var p1 := P3D(x, y - 1, z);
            var p2 := P3D(x, y, z);
            var p3 := P3D(x + 1, y, z);
            var p4 := P3D(x + 1, y - 1, z);
            Cube(p1, p2, p3, p4, Colors.Green);
        end;
        
        procedure CubeW(x: integer; y: integer; z: integer; block: byte);
        begin
            var p1 := P3D(x, y - 1, z + 1);
            var p2 := P3D(x, y, z + 1);
            var p3 := P3D(x, y, z);
            var p4 := P3D(x, y - 1, z);
            Cube(p1, p2, p3, p4, Colors.Green);
        end;
        
        procedure CubeB(x: integer; y: integer; z: integer; block: byte);
        begin
            var p1 := P3D(x, y - 1, z);
            var p2 := P3D(x + 1, y - 1, z);
            var p3 := P3D(x + 1, y - 1, z + 1);
            var p4 := P3D(x, y - 1, z + 1); 
            Cube(p1, p2, p3, p4, Colors.Green);
        end;
        
        procedure UpdateMesh();
        begin
            faceCount := 0;
        end;
        
        function Block(x: integer; y: integer; z: integer): byte;
        begin
            //result := world.Block(x + chunkX, y + chunkY, z + chunkZ);
        end;
        
        procedure CreateCube(x: integer; y: integer; z: integer);
        begin
            CubeT(0, 0, 0, 0);
            CubeN(0, 0, 0, 0);
            CubeE(0, 0, 0, 0);
            CubeS(0, 0, 0, 0);
            CubeW(0, 0, 0, 0);
            CubeB(0, 0, 0, 0);
        end;
    end;
 
 
//Main Method
begin
    Graph3D.Window.Caption := 'Custom Mesh';
    var chunk := new ChunkClass();
    //var world := new WorldClass();
    chunk.CreateCube(0, 0, 0);
    chunk.UpdateMesh();
end.