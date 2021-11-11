// https://twitter.com/okyrylchuk/status/1439680864452071425

Action a =[MyAttribute] () => { };               // [MyAttribute] lambda
Action<int> b =[return: MyAttribute] (x) => { };  // [MyAttribute] lambda
Action<int> c = ([MyAttribute] x) => { };         // [MyAttribute] x
var _ = string () => { return string.Empty; };

int one = (x => x)(1);

class MyAttribute : Attribute
{ }

