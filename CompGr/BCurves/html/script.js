const canvas = document.getElementById("canvas");
const context = canvas.getContext("2d");

const clb = document.getElementById("clear");
const sbmb = document.getElementById("submit");

const w = canvas.width;
const h=canvas.height;

const mouse = { x:0, y:0};      // координаты мыши
let draw = false;
let arr = [];
let res = [];
// нажатие мыши
canvas.addEventListener("mousedown", function(e){
      
    mouse.x = e.pageX - this.offsetLeft;
    mouse.y = e.pageY - this.offsetTop;
    //draw = true;
    context.fillRect(mouse.x,mouse.y,5,5)
    arr.push([mouse.x,mouse.y])

    //alert( arr.at(-1) )
    
});

clb.addEventListener("click", function(e){
    context.clearRect(0, 0, canvas.width, canvas.height);
    arr.splice(0,arr.length)
    res.splice(0,res.length)
});

sbmb.addEventListener("click", function(e){
    drawLines(context,getBezierCurve(arr,0.01))
    arr.splice(0,arr.length)
    res.splice(0,res.length)
});

function getBezierCurve(arr,step){
    if(step==undefined){
        step=0.01
    }
    for(var t=0;t<1+step;t+=step){
        if(t>1){
            t=1
        }
        var ind=res.length
        res[ind]=new Array(0,0)
        for(var i=0;i<arr.length;i++){
            var basis=getBezierBasis(i,arr.length-1,t)
            res[ind][0]+=arr[i][0]*basis
            res[ind][1]+=arr[i][1]*basis
           
        }
        
    }
    return res
}

function drawLines(ctx,arr){

        for(var i=0;i<arr.length-1;i++){
            draw=true
            ctx.beginPath();
            ctx.moveTo(arr[i][0],arr[i][1])
            ctx.lineTo(arr[i+1][0],arr[i+1][1])
            ctx.stroke();
            ctx.closePath();
        }
        
    }
function factorial(n){
        return n>1 ? n*factorial(n-1):1
    }
function getBezierBasis(i,n,t) {

    

    return factorial(n)/(factorial(n-i)*factorial(i))*Math.pow(t, i)*Math.pow(1 - t, n - i)  
}