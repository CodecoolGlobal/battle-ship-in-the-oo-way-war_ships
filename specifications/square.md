# SQUARE 
In this class we got 3 fields: 

--> static string named SYMBOL - this string is using while one of square wasn't hit yet. Default it is just an empty string.
--> string named aSquare - by
--> bool called IsHit - we use this field to declare if sqaure was hitted by player or not

In first constructror we assigned string SYMBOL to field aSquare and by default we assigned value False to field IsHit
In second constructor, default value of IsHit is the same but we assingned param string asquare to field aSquare  
In third constructor we assigned param boolean ishit to field IsHit and param string asquare to field aSquare

In class square we got 2 methods:
--> method GetSquare returns a string asquare

--> method toString returns formatted string, depends on IsHit value (True or False ):
    IsHit equals True - string.Format($"[{0}]", aSquare)
    IsHit equals False - string.Format($"[{0}]", SYMBOL)

Summarizing this class is responsible for marked squares (if square was hitted or not) and saving information about symbol of square.

