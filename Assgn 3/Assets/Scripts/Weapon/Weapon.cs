using System.Collections;
using System.Collections.Generic;

public class Weapon
{
    
    private string id, type, name, attack, range, speed;
    // private string name;

    public Weapon(string id, string type, string name, string attack, string range, string speed){
        this.id = id;
        this.type = type;
        this.name = name;
        this.attack = attack;
        this.range = range;
        this.speed = speed;
    }
    public string GetData(string data){

        if(data == "id")
            return this.id;
        else if(data == "type")
            return this.type;
        else if(data == "name")
            return this.name;
        else if(data == "attack")
            return this.attack;
        else if(data == "range")
            return this.range;
        else if(data == "speed")
            return this.speed;
        else
            return "";
    }
}
