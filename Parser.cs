﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser : MonoBehaviour {
    public int GlobalCount = 0;
    public Node currentNode = null;
    // Use this for initialization
    //want to avoid using expressions that are undefined at certain points ei 1/x
    void Start () {
	}
   
    public bool compareString(string s1, string s2)
    {
        char[] li = s1.ToCharArray();
        char[] li2 = s2.ToCharArray();
        for(int i = 0; i < li.Length; i++)
        {
            if(li[i+1] != li2[i])
            {
                return false;
            }
        }
        return true;
    }


    public void runTests()
    {
        currentNode = null;
        GlobalCount = 0;
        //Test 1 - test basic addition:
        string[] Test1 = { "15", "+", "5" };
        Node Node1 = ParseNodeTree(Test1);
        Debug.Assert(Node1.evaluate(0) == 20);

        currentNode = null;
        GlobalCount = 0;
        //Test 2 - test basic subtraction
        string[] Test2 = { "5", "-", "5" };
        Node Node2 = ParseNodeTree(Test2);
        Debug.Assert(Node2.evaluate(0) == 0);
        currentNode = null;
        GlobalCount = 0;
        //Test 3 - test basic multiplicaton
        string[] Test3 = { "5", "*", "5" };
        Node Node3 = ParseNodeTree(Test3);
        Debug.Assert(Node3.evaluate(0) == 25);

        currentNode = null;
        GlobalCount = 0;

        //Test 4 - test basic multiplicaton
        string[] Test4 = { "5", "/", "25" };
        Node Node4 = ParseNodeTree(Test4);
        Debug.Assert(Node4.evaluate(0) == 0.2f);

        currentNode = null;
        GlobalCount = 0;
        //Test 5 - test basic multiplicaton
        string[] Test5 = { "5", "/", "25" };
        Node Node5 = ParseNodeTree(Test4);
        Debug.Assert(Node5.evaluate(0) == 0.2f);
        //////////////////////////OK LETS STOP MESSING AROUND WOOO

        currentNode = null;
        GlobalCount = 0;
        //Test 6 - test addition with variable
        string[] Test6 = { "5", "+", "x" };
        Node Node6 = ParseNodeTree(Test6);
        Debug.Assert(Node6.evaluate(20) == 25);
        //assuming variables work with everything other operator since they work with addition because im lazy

        currentNode = null;
        GlobalCount = 0;
        //Test 7 - multiplication to addition
        string[] Test7 = { "5", "*", "2", "+", "2" };
        Node Node7 = ParseNodeTree(Test7);
        Debug.Assert(Node7.evaluate(20) == 12);
        currentNode = null;
        GlobalCount = 0;

        //Test 8 - multiplication to addition
        string[] Test8 = { "5", "+", "2", "*", "2" };
        Node Node8 = ParseNodeTree(Test8);
        Debug.Assert(Node8.evaluate(20) == 9);

        currentNode = null;
        GlobalCount = 0;

        //Test 9 - Division to addition
        string[] Test9 = { "5", "/", "2", "-", "2" };
        Node Node9 = ParseNodeTree(Test9);
        Debug.Assert(Node9.evaluate(20) == 0.5f);

        currentNode = null;
        GlobalCount = 0;

        //Test 10 - multiplication with addition with variable
        string[] Test10 = { "x", "/", "2", "-", "2" };
        Node Node10 = ParseNodeTree(Test10);
        Debug.Assert(Node10.evaluate(20) == 8);
        /////OK LETS TURN IT UP A NOTCH

        currentNode = null;
        GlobalCount = 0;

        //Test 11 - test getbracketText
        string[] test11 = { "(", "5", "+", "5", ")" };
        GlobalCount++;
        string[] s = getBracketText(test11);
        for (int i = 0; i < s.Length; i++)
        {
            Debug.Assert(s[i] == test11[i + 1]);
        }

        currentNode = null;
        GlobalCount = 0;

        //Test 12 - test getbracketText HARD
        string[] test12 = { "(", "5", "+", "(", "6", "-", "x", ")", ")" };
        GlobalCount++;
        string[] s2 = getBracketText(test12);
        for (int i = 0; i < s2.Length; i++)
        {
            Debug.Assert(s2[i] == test12[i + 1]);
        }
        
        currentNode = null;
        GlobalCount = 0;
        //Test 13 - brackets with basic addition
        string[] Test13 = {"(","5","+","6",")","+","5"};
        Node Node13 = ParseNodeTree(Test13);
        Debug.Assert(Node13.evaluate(2) == 16);
        print(Node13.evaluate(2) + ": pass");

        /////////////////ok lets stop FUCKING AROUND
        currentNode = null;
        GlobalCount = 0;
        //Test 14 - brackets with addition and multiplication
        string[] Test14 = { "(", "5", "+", "3", ")", "*", "2" };
        Node Node14 = ParseNodeTree(Test14);
        Debug.Assert(Node14.evaluate(2) == 16);
        print(Node14.evaluate(2) + ": pass");

        currentNode = null;
        GlobalCount = 0;
        //Test 15 - brackets with addition and multiplication
        string[] Test15 = { "20", "-", "(", "x", "+", "6", ")" };
        Node Node15 = ParseNodeTree(Test15);
        Debug.Assert(Node15.evaluate(5) == 9);
        print(Node15.evaluate(5) + ": pass");

        currentNode = null;
        GlobalCount = 0;
        //Test 16 - double brackets
        string[] Test16 = { "20", "-", "(", "x", "*", "(", "3", "+", "x", ")", ")" };
        Node Node16 = ParseNodeTree(Test16);
        Debug.Assert(Node16.evaluate(2) == 10);
        print(Node16.evaluate(2) + ": pass");

        currentNode = null;
        GlobalCount = 0;
        //Test 17 - double brackets-2
        string[] Test17 = { "5", "-", "(", "x", "/", "(", "x", "+", "x", ")", ")" };
        Node Node17 = ParseNodeTree(Test17);
        Debug.Assert(Node17.evaluate(2) == 4.5);
        print(Node17.evaluate(2) + ": pass");

        currentNode = null;
        GlobalCount = 0;
        //Test 18 - double brackets-2
        string[] Test18 = { "sin", "(", "5", "-", "5", ")" };
        Node Node18 = ParseNodeTree(Test18);
        Debug.Assert(Node18.evaluate(2) == 0);
        print(Node18.evaluate(2) + ": pass");

        currentNode = null;
        GlobalCount = 0;
        //Test 19 - misc
        string[] Test19 = { "sin", "(", "1", "-", "1", ")", "+","10"};
        Node Node19 = ParseNodeTree(Test19);
        Debug.Assert(Node19.evaluate(2) == 10);
        print(Node19.evaluate(2) + ": pass");

        currentNode = null;
        GlobalCount = 0;
        //test20 - exponents:1
        string[] Test20 = { "5", "^", "2" };
        Node Node20 = ParseNodeTree(Test20);
        Debug.Assert(Node20.evaluate(2) == 25);
        print(Node20.evaluate(2) + ": pass");

        currentNode = null;
        GlobalCount = 0;

        //test21 - exponents:2
        string[] Test21 = { "x", "^", "3" };
        Node Node21 = ParseNodeTree(Test21);
        Debug.Assert(Node21.evaluate(2) == 8);
        print(Node21.evaluate(2) + ": pass");
        
        currentNode = null;
        GlobalCount = 0;

        //test22 - exponents:3
        string[] Test22 = { "x", "^", "x", "+","3"};
        Node Node22 = ParseNodeTree(Test22);
        Debug.Assert(Node22.evaluate(2) == 7);
        print(Node22.evaluate(2) + ": pass");

        currentNode = null;
        GlobalCount = 0;

        //test23 - cosine
        string[] Test23 = { "cos", "(", "3","-","3",")" };
        Node Node23 = ParseNodeTree(Test23);
        Debug.Assert(Node23.evaluate(2) == 1);
        print(Node23.evaluate(2) + ": pass");


        currentNode = null;
        GlobalCount = 0;

    }

    public void differentiationTests()
    {
        currentNode = null;
        GlobalCount = 0;
        //Test 1 - test basic addition:
        string[] Test1 = { "5", "*", "x" };
        Node Node1 = ParseNodeTree(Test1);
        Node NodeD1 = Node1.differentiate();
        Debug.Assert(NodeD1.evaluate(2) == 5);
        print(NodeD1.evaluate(0));
        currentNode = null;
        GlobalCount = 0;
        //Test 2 - test basic addition:
        string[] Test2 = { "5", "+", "x" };
        Node Node2 = ParseNodeTree(Test2);
        Node NodeD2 = Node2.differentiate();
        Debug.Assert(NodeD2.evaluate(2) == 1);
        print(NodeD2.evaluate(0));
        currentNode = null;
        GlobalCount = 0;
        //Test 3 - test basic addition:
        string[] Test3 = { "x", "*", "x" };
        Node Node3 = ParseNodeTree(Test3);
        Node NodeD3 = Node3.differentiate();
        Debug.Assert(NodeD3.evaluate(5) == 10);
        print(NodeD3.evaluate(5));
        currentNode = null;
        GlobalCount = 0;
        //Test 4 - test basic addition:
        string[] Test4 = { "x", "/", "(", "x", "*", "5", ")" };
        Node Node4 = ParseNodeTree(Test4);
        Node NodeD4 = Node4.differentiate();
        Debug.Assert(NodeD4.evaluate(20) == 0);
        print(NodeD4.evaluate(20));
        currentNode = null;
        GlobalCount = 0;
        //Test 5 - test basic addition:
        string[] Test5 = { "sin", "(", "x", "*", "5", ")" };
        Node Node5 = ParseNodeTree(Test5);
        Node NodeD5 = Node5.differentiate();
        Debug.Assert(NodeD5.evaluate(0) == 5);
        print(NodeD5.evaluate(0));
        currentNode = null;
        GlobalCount = 0;

    }
    

    public Node ParseNodeTree(string[] fun)
    {
        if(fun.Length < 3)
        {
            print("less than 3");
            return null;
        }
        //situation where this is the first iteration
        if(currentNode == null)
        {

            Node Child1 = parseNodeType(fun);
            if (GlobalCount == fun.Length)
            {
                return Child1;
            }
            Node Parent = parseNodeType(fun);
            Node Child2 = parseNodeType(fun);
           
            Parent.Child1 = Child1;
            Parent.Child2 = Child2;
            currentNode = Parent;
            
        }
        else
        {//situation where this isnt the first iteration

            
            Node Parent = parseNodeType(fun);
            Node Child2 = parseNodeType(fun);
            if(isOperator(Parent) == 1)// + or -
            {
                currentNode = currentNode.getHead();
                currentNode.Parent = Parent;
                Parent.Child1 = currentNode;
                Parent.Child2 = Child2;
            }
            else if(isOperator(Parent) == 2)// * or /
            {
                Parent.Child1 = currentNode.Child2;
                Parent.Child2 = Child2;
                Parent.Parent = currentNode;
                currentNode.Child2 = Parent;
                currentNode = Parent;
            }
        }
        if(GlobalCount < fun.Length)
        {
            ParseNodeTree(fun);
        }
        return currentNode.getHead();
    }

    public void Reset()
    {
        GlobalCount = 0;
        currentNode = null;
    }

    public Node parseNodeType(string[] text)
    { 
        if(text[GlobalCount] == "*")
        {
            GlobalCount++;
            return new Multiply_Operator();
        }else if (text[GlobalCount] == "-")
        {
            GlobalCount++;
            return new Minus_Operator();
        }
        else if (text[GlobalCount] == "+")
        {
            GlobalCount++;
            return new Add_Operator();
        }
        else if (text[GlobalCount] == "/")
        {
            GlobalCount++;
            return new Divide_Operator();
        }
        else if(text[GlobalCount] == "x")
        {
            GlobalCount++;
            return new Variable();
        }
        else if(text[GlobalCount] == "(")
        {
            GlobalCount++;
            Parser newParse = new Parser();
            string[] sss = getBracketText(text);
            Node tree = newParse.ParseNodeTree(sss);
            return tree.getHead();
        }
        else if(text[GlobalCount] == "sin")
        {
            GlobalCount+=2;
            Parser newParse = new Parser();
            string[] sss = getBracketText(text);
            Node tree = newParse.ParseNodeTree(sss);
            Sin_Operator sinOp = new Sin_Operator();
            sinOp.Child1 = tree;
            return sinOp;
        }
        else if (text[GlobalCount] == "cos")
        {
            GlobalCount += 2;
            Parser newParse = new Parser();
            string[] sss = getBracketText(text);
            Node tree = newParse.ParseNodeTree(sss);
            Cosine_Operator sinOp = new Cosine_Operator();
            sinOp.Child1 = tree;
            return sinOp;
        }
        else if (text[GlobalCount] == "^")
        {
            GlobalCount++;
            return new Exponent_Operator();
        }
        else
        {
            GlobalCount++;
            return new Operand(castToNumber(text[GlobalCount-1]));
        }
    }

    public string[] getBracketText(string[] text)
    {
        string[] reText = new string[100];
            int size = 0;
            int bracketCount = 0;
            while(GlobalCount < text.Length)
            {
            if (text[GlobalCount] == ")" && bracketCount == 0)
            {
                GlobalCount++;
                break;
            }
            else { 
                if (text[GlobalCount] == ")")
                {
                    bracketCount--;
                }
                else if (text[GlobalCount] == "(")
                {
                    bracketCount++;
                }
                reText[size] = text[GlobalCount];
                size++;
                GlobalCount++;
            }
            }
        string[] retext2 = new string[size];
        for (int i = 0; i < size; i++)
        {
            retext2[i] = reText[i];
        }
        return retext2;
    }

    public float castToNumber(string text)
    {
        return (float) System.Convert.ToDouble(text);
    }
	

    public int isOperator(string text)
    {
        if (text == "+" || text == "-") return 1;
        else if (text == "*" || text == "/" || text == "cos") return 2;
        else if (text == "sin" || text == "cos") return 3;
        else return 0;
    }

    public int isOperator(Node n)
    {
        if (n.GetType() == typeof(Add_Operator) || n.GetType() == typeof(Minus_Operator)) return 1;
        else if (n.GetType() == typeof(Multiply_Operator) || n.GetType() == typeof(Divide_Operator) || n.GetType() == typeof(Exponent_Operator)) return 2;
        else if (n.GetType() == typeof(Sin_Operator) || n.GetType() == typeof(Cosine_Operator)) return 3;
        return 0;
    }

    public bool isOperand(string text)
    {
        return (text != "*" || text != "-" || text != "+" || text != "/" || text != "sin" || text != "^" || text != "cos");
    }
    
}
