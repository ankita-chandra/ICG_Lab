var vertices = [
   -0.8,0.5,0.0,
   -0.8,-0.8,0.0,
   0.8,-0.8,0.0,
   0.8,0.5,0.0
];

indices = [0,1,2,0,2,3];

var vertex_buffer, Index_Buffer;
var vertShader,fragShader, shaderProgram;

var vertCode =
'attribute vec3 coordinates;' +

'void main(void) {' +
' gl_Position = vec4(coordinates, 1.0);' +
'}';

var fragCode =
'void main(void) {' +
' gl_FragColor = vec4(0.8, 0.75, 0, 0.4);' +
'}';

var CreateBuffers=function(gl)
{
    vertex_buffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, vertex_buffer);
    gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(vertices), gl.STATIC_DRAW);
    gl.bindBuffer(gl.ARRAY_BUFFER, null);

    Index_Buffer = gl.createBuffer();
    gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, Index_Buffer);
    gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, new Uint16Array(indices), gl.STATIC_DRAW);
    gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, null);
};

var CreateShaders=function(gl)
{
    vertShader = gl.createShader(gl.VERTEX_SHADER);
    gl.shaderSource(vertShader, vertCode);
    gl.compileShader(vertShader);

    fragShader = gl.createShader(gl.FRAGMENT_SHADER);
    gl.shaderSource(fragShader, fragCode);
    gl.compileShader(fragShader);

    shaderProgram = gl.createProgram();
    gl.attachShader(shaderProgram, vertShader);
    gl.attachShader(shaderProgram, fragShader);
    gl.linkProgram(shaderProgram);
    gl.useProgram(shaderProgram);
};

var ClearCanvas=function(gl,canvas)
{
    gl.clearColor(1, 1, 1, 1);
    gl.enable(gl.DEPTH_TEST);
    gl.clear(gl.COLOR_BUFFER_BIT);
    gl.viewport(0,0,canvas.width,canvas.height);
};

var Start=function()
{
    var canvas = document.getElementById('my_Canvas');
    var gl = canvas.getContext('webgl');
    CreateBuffers(gl);
    CreateShaders(gl);
    gl.bindBuffer(gl.ARRAY_BUFFER, vertex_buffer);
    gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, Index_Buffer);

    var coord = gl.getAttribLocation(shaderProgram, "coordinates");
    gl.vertexAttribPointer(coord, 3, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(coord);

    ClearCanvas(gl,canvas);

    // var ctx = document.createElement("canvas").getContext("2d");
    // ctx.canvas.width  = 800;
    // ctx.canvas.height = 600;
    // ctx.font = "20px monospace";
    // ctx.textAlign = "center";
    // ctx.textBaseline = "middle";
    // ctx.fillStyle = "red";
    // ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
    // ctx.fillText("HOLA", 400,300);

    gl.drawElements(gl.TRIANGLES, indices.length, gl.UNSIGNED_SHORT,0);
};
