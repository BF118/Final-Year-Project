var teamsize;
teamsize = 0;
var emptystring;
emptystring = String.empty;




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
      request.open("POST", "WEBHOOK");
      
      //Get Signup Elements
      var eventTime = document.getElementById("eventTime").value;
      var basetank = document.getElementById("baseTank").value;
      var dps = document.getElementById("dps").value;
      var anyrole = document.getElementById("anyRole").value;
      var learner = document.getElementById("learner").value;

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
      request.open("POST", "WEBHOOK");
      var basetank= document.getElementById("baseTank").value;
      var dps = document.getElementById("dps").value;
      var anyrole = document.getElementById("anyRole").value;
      var learner = document.getElementById("learner").value;
      var bombtank = document.getElementById("bombTank").value;
      var toplure = document.getElementById("topLure").value;
    
    
      request.setRequestHeader('Content-type', 'application/json');
    var myEmbed={
             color: 0x0099ff,    
             author: {
                name: " " 
  },
  title: "Encounter 2 Selected",
  description: "encounter2",
  fields: [
		{
			name: 'BaseTank user',
			value: basetank,
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
        {
			name: 'bombtank User',
			value: bombtank,
            inline: true,
		},
        {
			name: 'toplure user',
			value: toplure,
            inline: true,
		},
      ],
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
      request.open("POST", "WEBHOOK");
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


function RemoveSignup(){
    
    signUpBaseButton.style.display = 'none';
    signUpDpsButton.style.display = 'none';
    signUpAnyRoleButton.style.display = 'none';
    signUpLearnerButton.style.display ='none';
    
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
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('bombTank');
    document.getElementById('bombTank').value = answer;

}
function signUpTopLure(){
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('topLure');
    document.getElementById('topLure').value = answer;

}
function signUprainShield(){
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('rainShield');
    document.getElementById('rainShield').value = answer;
}
function signUpShatter(){
    var input = document.getElementById("username").value;
    var answer = input;
    document.getElementById('shatter');
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
    
