var teamsize;
teamsize = 0;
var emptystring;
emptystring = "\u200B";


//search
function search(){
    var input = document.getElementById("searchbox").value;
    input= input.toLowerCase();
    if(input == "encounter1")
    {
        window.location.href = ("http://bf118.webhosting.canterbury.ac.uk/index.html");
    }
    if(input == "encounter2"){
        window.location.href = ("http://bf118.webhosting.canterbury.ac.uk/encounter2.html");
    }
    if(input == "encounter3")
    {
        window.location.href = ("http://bf118.webhosting.canterbury.ac.uk/encounter3.html");
    }
    if(input == "encounter4")
    {
        window.location.href = ("http://bf118.webhosting.canterbury.ac.uk/encounter4.html");
    }
}




//encounter to discord scripts
function Createsheet() {
    var request = new XMLHttpRequest();
    request.open("POST", "Token");
      
    //Get Signup Elements
    var eventTime = document.getElementById("eventTime").value;
    var basetank = document.getElementById("baseTank").value;
    var dps = document.getElementById("dps").value;
    var anyrole = document.getElementById("anyRole").value;
    var learner = document.getElementById("learner").value;

    
    if(basetank === ""){
        basetank=emptystring;
    }
    if(eventTime === ""){
        eventTime="Now";
    }
    if(dps === ""){
        dps=emptystring;
    }
    if(anyrole === ""){
        anyrole=emptystring;
    }
    if(learner === ""){
        learner=emptystring;
    }

    request.setRequestHeader('Content-type', 'application/json');
    var myEmbed={
        color: 0x0066ff, 
             author: {
    name: " " 
  },
  title: "Encounter 1",
  description: "Encounter 1 has been Selected",
  fields: [
        {
			name: 'Time',
			value: eventTime,
		},
        {
			name: 'Looting',
			value: 'Test',
		},
        {
			name: 'Team Size',
			value: teamsize + '/7',
		},
		{
			name: '1x BaseTank:  ',
			value: basetank,
            inline: true,
		},//basetank
		{
			name: '1x DPS:  ',
			value: dps,
            inline: true,
		},//dps
        {
			name: '1x Anyrole:  ',
			value: anyrole,
            inline: true,
		},//anyrole
        {
			name: '1x learner:  ',
			value: learner,
            inline: true,
		},//learner
      ],
        timestamp: new Date(),
        };

      var params = {
        username: "SignUpSheetBot",
        avatar_url: "",
        embeds:[myEmbed]
      }

      request.send(JSON.stringify(params));
        
    }

function Createsheet2() {
           var request = new XMLHttpRequest();
      request.open("POST", "Token");
      
      var eventTime = document.getElementById("eventTime").value;
      var basetank= document.getElementById("baseTank").value;
      var dps = document.getElementById("dps").value;
      var anyrole = document.getElementById("anyRole").value;
      var learner = document.getElementById("learner").value;
      var bombtank = document.getElementById("bombTank").value;
      var toplure = document.getElementById("topLure").value;
    
    
      request.setRequestHeader('Content-type', 'application/json');
    var myEmbed={
             color: 0x36E00D,    
             author: {
                name: " " 
  },
  title: "Encounter 2 Selected",
  description: "encounter2",
  fields: [
        {
			name: 'Time',
			value: eventTime,
		},
        {
			name: 'Looting',
			value: 'Test',
		},
        {
			name: 'Team Size',
			value: teamsize + '/7',
		},
		{
			name: '1x Basetank:  ',
			value: basetank,
            inline: true,
		},
		{
			name: '1x DPS:  ',
			value: dps,
            inline: true,
		},
        {
			name: '1x AnyRole:  ',
			value: anyrole,
            inline: true,
		},
        {
			name: '1x learner:  ',
			value: learner,
            inline: true,
		},
        {
			name: '1x Bombtank:  ',
			value: bombtank,
            inline: true,
		},
        {
			name: '1x Toplure:  ',
			value: toplure,
            inline: true,
		},
      ],
        timestamp: new Date(),
        };

      var params = {
        username: "Signupsheetbot",
        avatar_url: "",
        embeds:[myEmbed]
      }

      request.send(JSON.stringify(params));
    }

function Createsheet3() {
           var request = new XMLHttpRequest();
      request.open("POST", "Token");
    
      var eventTime = document.getElementById("eventTime").value;
      var basetank= document.getElementById("baseTank").value;
      var dps = document.getElementById("dps").value;
      var anyrole = document.getElementById("anyRole").value;
      var learner = document.getElementById("learner").value;
      var rainshield = document.getElementById("rainShield").value;
      var shatter = document.getElementById("shatter").value;
      var cleanse = document.getElementById("cleanse").value;
      var realmOne = document.getElementById("realmOne").value;
      var realmTwo = document.getElementById("realmTwo").value;
      
    request.setRequestHeader('Content-type', 'application/json');
        var myEmbed={
        color: 0x0066ff, 
             author: {
    name: " " 
  },
  title: "Encounter 3 Selected",
  description: "encounter3",
  fields: [
        {
			name: 'Time',
			value: eventTime,
		},
        {
			name: 'Looting',
			value: 'Test',
		},
        {
			name: 'Team Size',
			value: teamsize + '/7',
		},
		{
			name: 'BaseTank user',
			value: basetank,
            inline: true,
		},
        {
			name: 'Rainshield user',
			value: rainshield,
            inline: true,
		},
        {
			name: 'shatter user',
			value: shatter,
            inline: true,
		},
        {
			name: 'cleanse user',
			value: cleanse,
            inline: true,
		},
        {
			name: 'realmone user',
			value: realmOne,
            inline: true,
		},
        {
			name: 'realm two user',
			value: realmTwo,
            inline: true,
		},
		{
			name: 'DPS User',
			value: dps,
            inline: true,
		},
        {
			name: 'anyrole User',
			value: anyrole,
            inline: true,
		},
        {
			name: 'learner User',
			value: learner,
            inline: true,
		},
      ],
        timestamp: new Date(),
        };

      var params = {
        username: "Signupsheetbot",
        avatar_url: "",
        embeds:[myEmbed]
      }

      request.send(JSON.stringify(params));
    }

function Createsheet4() {
   var request = new XMLHttpRequest();
    request.open("POST", "Token");
      
    //Get Signup Elements
    var eventTime = document.getElementById("eventTime").value;
    var basetank = document.getElementById("baseTank").value;
    var dps = document.getElementById("dps").value;
    var anyrole = document.getElementById("anyRole").value;
    var learner = document.getElementById("learner").value;
    var chinner = document.getElementById("chinner").value;
    var hammer = document.getElementById("hammer").value;
    var uMinion = document.getElementById("uMinion").value;
    var gMinion = document.getElementById("gMinion").value;
    var cMinion = document.getElementById("cMinion").value;
    var fMinion = document.getElementById("fMinion").value;
    
    
    if(basetank === ""){
        basetank=emptystring;
    }
    if(eventTime === ""){
        eventTime="Now";
    }
    if(dps === ""){
        dps=emptystring;
    }
    if(anyrole === ""){
        anyrole=emptystring;
    }
    if(learner === ""){
        learner=emptystring;
    }
    if(chinner ===""){
        chinner=emptystring;
    }
    if(hammer === ""){
        hammer=emptystring;
    }
    if(uMinion === ""){
        uMinion = emptystring;
    }
    if(gMinion === ""){
        gMinion = emptystring;
    }
    if(cMinion === ""){
        cMinion = emptystring;
    }
    if(fMinion === ""){
        fMinion = emptystring;
    }
    
    request.setRequestHeader('Content-type', 'application/json');
    var myEmbed={
        color: 0x0066ff, 
             author: {
    name: " " 
  },
  title: "Encounter 4",
  description: "Encounter 4 has been Selected",
  fields: [
        {
			name: 'Time',
			value: eventTime,
		},
        {
			name: 'Looting',
			value: 'Test',
		},
        {
			name: 'Team Size',
			value: teamsize + '/7',
		},
		{
			name: '1x BaseTank:  ',
			value: basetank,
            inline: true,
		},//basetank
		{
			name: '1x DPS:  ',
			value: dps,
            inline: true,
		},//dps
        {
			name: '1x Anyrole:  ',
			value: anyrole,
            inline: true,
		},//anyrole
        {
			name: '1x learner:  ',
			value: learner,
            inline: true,
		},//learner
        {
			name: '1x Chinner:  ',
			value: chinner,
            inline: true,
		},//Chinner
        {
			name: '1x Hammer:  ',
			value: hammer,
            inline: true,
		},//Hammer
        {
            name: '1x Umbra Minion:  ',
            value: uMinion,
            inline: true,
        },
        {
            name: '1x Glacies Minion:  ',
            value: gMinion,
            inline: true,
        },
        {
            name: '1x Cruor Minion:  ',
            value: cMinion,
            inline: true,
        },
        {
            name: '1x Fumus Minion:  ',
            value: fMinion,
            inline: true,
        },
      ],
        timestamp: new Date(),
        };

      var params = {
        username: "SignUpSheetBot",
        avatar_url: "",
        embeds:[myEmbed]
      }

      request.send(JSON.stringify(params));
    }

function RemoveSignup(){
    signUpBaseButton.style.display = 'none';
    signUpDpsButton.style.display = 'none';
    signUpAnyRoleButton.style.display = 'none';
    signUpLearnerButton.style.display = 'none';
    
}
function RemoveSignup2(){
    signUpBaseButton.style.display = 'none';
    signUpDpsButton.style.display = 'none';
    signUpAnyRoleButton.style.display = 'none';
    signUpLearnerButton.style.display = 'none';
    signUpBombTankButton.style.display = 'none';
    signUpTopLureButton.style.display = 'none';

}
function RemoveSignup3(){
    signUpBaseButton.style.display = 'none';
    signUpDpsButton.style.display = 'none';
    signUpAnyRoleButton.style.display = 'none';
    signUpLearnerButton.style.display = 'none';
    signUpRealmOne.style.display ='none';
    
}
function RemoveSignup4(){
    
    signUpBaseButton.style.display = 'none';
    signUpDpsButton.style.display = 'none';
    signUpAnyRoleButton.style.display = 'none';
    signUpLearnerButton.style.display = 'none';
    
    
    signUpChinnerButton.style.display = 'none';
    signUpHammerButton.style.display = 'none';
    signUpUMinionButton.style.display = 'none';
    signUpGMinionButton.style.display = 'none';
    signUpCMinionButton.style.display = 'none';
    signUpFMinionButton.style.display = 'none';
}

function ClearSignup(){
    teamsize = 0;
    var basetankClear = document.getElementById("baseTank");
    basetankClear.value = emptystring;
    var dpsClear = document.getElementById("dps");
    dpsClear.value = emptystring;
    var learnerClear = document.getElementById("learner");
    learnerClear.value = emptystring;
    var anyRoleClear = document.getElementById("anyRole");
    anyRoleClear.value = emptystring;
}
function ClearSignup2(){
    teamsize = 0;
    var basetankClear = document.getElementById("baseTank");
    basetankClear.value = emptystring;
    var dpsClear = document.getElementById("dps");
    dpsClear.value = emptystring;
    var learnerClear = document.getElementById("learner");
    learnerClear.value = emptystring;
    var anyRoleClear = document.getElementById("anyRole");
    anyRoleClear.value = emptystring;
    var bombtankclear = document.getElementById("bombTank")
    bombtankclear.value = emptystring;
    var toplureclear = document.getElementById("topLure")
}
function ClearSignup4(){
    teamsize = 0;
    var basetankClear = document.getElementById("baseTank");
    basetankClear.value = emptystring;
    var dpsClear = document.getElementById("dps");
    dpsClear.value = emptystring;
    var learnerClear = document.getElementById("learner");
    learnerClear.value = emptystring;
    var anyRoleClear = document.getElementById("anyRole");
    anyRoleClear.value = emptystring;
    var chinnerclear = document.getElementById("chinner");
    chinnerclear.value = emptystring;
    var hammerclear = document.getElementById("hammer")
    hammerclear.value = emptystring;
    var uclear = document.getElementById("uMinion");
    uclear.value = emptystring;
    var gclear = document.getElementById("gMinion");
    gclear.value = emptystring;
    var cclear = document.getElementById("cMinion");
    cclear.value = emptystring;
    var fclear = document.getElementById("fMinion");
    fclear.value = emptystring;
}



//signup sheets
function signUpBase(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('baseTank').value = answer;
}
function signUpDps(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('dps').value = answer;

}
function signUpLearner(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('learner').value = answer;
   
}
function signUpAnyRole(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('anyRole').value = answer;
 
}
function signUpBombTank(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('bombTank').value = answer;

}
function signUpTopLure(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('topLure').value = answer;

}
function signUprainShield(){
    teamsize++;    
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('rainShield').value = answer;
}
function signUpShatter(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('shatter').value = answer;
}
function signUpCleanse(){
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('cleanse');
    document.getElementById('cleanse').value = answer;
}
function signUpRealmOne(){
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('realmOne');
    document.getElementById('realmOne').value = answer;
}
function signUpRealmTwo(){
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('realmTwo');
    document.getElementById('realmTwo').value = answer;
}
function signUpChinner(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('chinner').value = answer;
}
function signUpHammer(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('hammer').value = answer;

}
function signUpUMinion(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('uMinion').value = answer;
}
function signUpGMinion(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('gMinion').value = answer;
}
function signUpFMinion(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('fMinion').value = answer;
}
function signUpCMinion(){
    teamsize++;
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('cMinion').value = answer;
}
   
    
