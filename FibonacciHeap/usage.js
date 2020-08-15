var resultBox;
var inputBox;
function init() {
    resultBox = document.getElementById("result");
    inputBox = document.getElementById("input");
    document.getElementById('tblResult').style.display='none';
}

function Extract_WithDefaultCompare() {

    resultBox.innerHTML = "";
    inputBox.innerHTML = "";

    var heap = new FibonacciHeap();

    heap.insert(3);
    heap.insert(7);
    // Insert keys and values
    heap.insert(8, { foo: 'bar' });
    heap.insert(1, { foo: 'baz' });

    inputBox.innerHTML = 'key: 3 value: ---<br/>';
    inputBox.innerHTML += 'key: 7 value: ---<br/>';
    inputBox.innerHTML += 'key: 8 value: ' + JSON.stringify({ foo: 'bar' }) + '<br/>';
    inputBox.innerHTML += 'key: 1 value: ---' + JSON.stringify({ foo: 'baz' }) + '<br/>';

    // Extract all nodes in order
    while (!heap.isEmpty()) {
        var node = heap.extractMinimum();
        resultBox.innerHTML += 'key: ' + node.key + ', value: ' + node.value;
        resultBox.innerHTML += "<br/>"
    }
    document.getElementById('tblResult').style.display='block';
}

function Extract_WithCustomCompare() {

    resultBox.innerHTML = "";
    inputBox.innerHTML = "";

    var heap = new FibonacciHeap(function (a, b) {
        return (a.key + a.value).localeCompare(b.key + b.value);
    });
    heap.insert('2', 'B');
    heap.insert('1', 'a');
    heap.insert('1', 'A');
    heap.insert('2', 'b');

    inputBox.innerHTML = 'key: 2, value: B<br/>';
    inputBox.innerHTML += 'key: 1, value: a<br/>';
    inputBox.innerHTML += 'key: 1, value: A<br/>';
    inputBox.innerHTML += 'key: 2, value: b<br/>';

    // Extract all nodes in order
    while (!heap.isEmpty()) {
        var node = heap.extractMinimum();
        resultBox.innerHTML += 'key: ' + node.key + ', value: ' + node.value;
        resultBox.innerHTML += "<br/>"
    }
    document.getElementById('tblResult').style.display='block';
}