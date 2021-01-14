import {Bolnica} from "./bolnica.js"



const main=document.createElement("div");
main.className="bod";
document.body.appendChild(main);
const kontejner1 = document.createElement("div");
kontejner1.className="main";
main.appendChild(kontejner1);
let label=document.createElement("h2");
label.innerHTML="Unos i brisanje bolnice";
kontejner1.appendChild(label);
label=document.createElement("label");
label.innerHTML="Uneti naziv bolnice: ";
kontejner1.appendChild(label);
let input = document.createElement("input");
input.className="imeBolnice";
kontejner1.appendChild(input);
label = document.createElement("br");
kontejner1.appendChild(label);
label=document.createElement("label");
label.innerHTML="Uneti broj soba bolnice: ";
kontejner1.appendChild(label);
input = document.createElement("input");
input.className="brojSoba";
input.type="number";
kontejner1.appendChild(input);
label = document.createElement("br");
kontejner1.appendChild(label);
label=document.createElement("label");
label.innerHTML="Uneti kapacitet soba bolnice: ";
kontejner1.appendChild(label);
input = document.createElement("input");
input.className="kapacitetSoba";
input.type="number";
kontejner1.appendChild(input);
label = document.createElement("br");
kontejner1.appendChild(label);
label=document.createElement("label");
label.innerHTML="Uneti broj smena bolnice: ";
kontejner1.appendChild(label);
input = document.createElement("input");
input.className="brojSmena";
input.type="number";
kontejner1.appendChild(input);
label = document.createElement("br");
kontejner1.appendChild(label);
const dodaj=document.createElement("button");
dodaj.innerHTML="Dodaj bolnicu";
kontejner1.appendChild(dodaj);
dodaj.onclick=(ev)=>{
    let ime =kontejner1.querySelector(".imeBolnice").value;
    let brs=kontejner1.querySelector(".brojSoba").value;
    let kap=kontejner1.querySelector(".kapacitetSoba").value;
    let brsm=kontejner1.querySelector(".brojSmena").value;
fetch("https://localhost:5001/Bolnica/UpisBolnice",{
    method:"POST",
    headers:{
        "Content-Type":"application/json"
    },
    body: JSON.stringify({
        naziv:ime,
        brojSoba:brs,
        kapacitetSobe:kap,
        uSmeni:brsm,
    })
});
}
label = document.createElement("br");
kontejner1.appendChild(label);
input = document.createElement("input");
input.className="idBolnice";
input.type="number";
kontejner1.appendChild(input);
label = document.createElement("br");
kontejner1.appendChild(label);
const dodaj2=document.createElement("button");
dodaj2.innerHTML="Dodaj ostalo";
kontejner1.appendChild(dodaj2);
dodaj2.onclick=(ev)=>{
    let brs=kontejner1.querySelector(".brojSoba").value;
    let kap=kontejner1.querySelector(".kapacitetSoba").value;
    let id=kontejner1.querySelector(".idBolnice").value;
    let brsm=kontejner1.querySelector(".brojSmena").value;
for(let i=0;i<brs;i++)
fetch("https://localhost:5001/Bolnica/UpisSobe/"+id,{
    method:"POST",
    headers:{
        "Content-Type":"application/json"
    },
    body: JSON.stringify({
        brojSobe:i+1,
        odelenje:"",
        maxPrimljeni:kap,
    })
});
for(let i=0;i<brsm;i++)
fetch("https://localhost:5001/Bolnica/UpisSmene/"+id,{
    method:"POST",
    headers:{
        "Content-Type":"application/json"
    },
    body: JSON.stringify({
        brojSmene:0,
        broj:i+1,
    })
});
location.reload();
}
const kontejner2 = document.createElement("div");
kontejner2.className="main";
main.appendChild(kontejner2);
label=document.createElement("h2");
label.innerHTML="Azuriranje bolnice";
kontejner2.appendChild(label);
label=document.createElement("label");
label.innerHTML="Uneti ID bolnice: ";
kontejner2.appendChild(label);
input = document.createElement("input");
input.className="id2";
input.type="number";
kontejner2.appendChild(input);
label = document.createElement("br");
kontejner2.appendChild(label);
label=document.createElement("label");
label.innerHTML="Uneti naziv bolnice: ";
kontejner2.appendChild(label);
input = document.createElement("input");
input.className="imeBolnice2";
kontejner2.appendChild(input);
label = document.createElement("br");
kontejner2.appendChild(label);
label=document.createElement("label");
label.innerHTML="Uneti broj soba bolnice: ";
kontejner2.appendChild(label);
input = document.createElement("input");
input.className="brojSoba2";
input.type="number";
kontejner2.appendChild(input);
label = document.createElement("br");
kontejner2.appendChild(label);
label=document.createElement("label");
label.innerHTML="Uneti kapacitet soba bolnice: ";
kontejner2.appendChild(label);
input = document.createElement("input");
input.className="kapacitetSoba2";
input.type="number";
kontejner2.appendChild(input);
label = document.createElement("br");
kontejner2.appendChild(label);
label=document.createElement("label");
label.innerHTML="Uneti broj smena bolnice: ";
kontejner2.appendChild(label);
input = document.createElement("input");
input.className="brojSmena2";
input.type="number";
kontejner2.appendChild(input);
label = document.createElement("br");
kontejner2.appendChild(label);
const azuriraj=document.createElement("button");
azuriraj.innerHTML="Azuriraj bolnicu";
kontejner2.appendChild(azuriraj);
azuriraj.onclick=(ev)=>
{
    let id,ime,brs,kap,brsm;
        id=kontejner2.querySelector(".id2").value;
        ime=kontejner2.querySelector(".imeBolnice2").value;
        brs=kontejner2.querySelector(".brojSoba2").value;
        kap=kontejner2.querySelector(".kapacitetSoba2").value;
        brsm=kontejner2.querySelector(".brojSmena2").value;
    fetch("https://localhost:5001/Bolnica/IzmeniBolnicu",{
        method:"PUT",
        headers:{
            "Content-Type":"application/json"
        },
        body: JSON.stringify({
            id:id,
            naziv:ime,
            brojSoba:brs,
            kapacitetSobe:kap,
            uSmeni:brsm,
        })
    });
    window.location.reload();
}
const kontejner3=document.createElement("div");
kontejner3.className="main";
main.appendChild(kontejner3);
label=document.createElement("h2");
label.innerHTML="Brisanje bolnice";
kontejner3.appendChild(label);
label=document.createElement("label");
label.innerHTML="Uneti ID bolnice: ";
kontejner3.appendChild(label);
input = document.createElement("input");
input.className="id1";
input.type="number";
kontejner3.appendChild(input);
label = document.createElement("br");
kontejner3.appendChild(label);
const izbrisi=document.createElement("button");
izbrisi.innerHTML="Izbrisi bolnicu";
kontejner3.appendChild(izbrisi);
izbrisi.onclick=(ev)=>{
    let id=document.querySelector(".id1").value;
    fetch("https://localhost:5001/Bolnica/IzbrisiBolnicu?id="+id,{method:"DELETE"});
}
label = document.createElement("br");
kontejner3.appendChild(label);
label=document.createElement("h2");
label.innerHTML="Crtanje bolnica";
kontejner3.appendChild(label);
const crtaj=document.createElement("button");
crtaj.innerHTML="Crtaj bolnice";
kontejner3.appendChild(crtaj);
crtaj.onclick=(ev)=>
{
fetch("https://localhost:5001/Bolnica/PreuzmiBolnice").then(p=>{
    p.json().then(data=>{
        data.forEach(bolnica => {
           const bolnica1=new Bolnica(bolnica.id,bolnica.naziv,bolnica.brojSoba,bolnica.kapacitetSobe,bolnica.uSmeni);
            
            bolnica1.crtajBolnicu(document.body);
            bolnica1.sobe.forEach(soba=>{
                var s=soba;
                    s.azurirajSobu(soba.pacijenti,soba.odelenje,soba.hitno);
                
            });

            bolnica1.smene.forEach(smena=>{
                var s=bolnica1.smene[smena.broj-1];
                    s.azurirajSmenu(smena.lekar,smena.brojSmene);
            });

            bolnica1.lekari.forEach(lekar=>{
                bolnica1.dodajLekara(lekar);
            })
        });
    });
});
}
label = document.createElement("br");
kontejner3.appendChild(label);
label=document.createElement("h2");
label.innerHTML="Zaposljavanje lekara";
kontejner3.appendChild(label);
label = document.createElement("label");
label.innerHTML="Ime lekara";
kontejner3.appendChild(label);
input = document.createElement("input");
input.type="text";
input.className="lekarIme";
kontejner3.appendChild(input);
label = document.createElement("label");
label.innerHTML="Prezime lekara";
kontejner3.appendChild(label);
input = document.createElement("input");
input.type="text";
input.className="lekarPrezime";
kontejner3.appendChild(input);
label = document.createElement("br");
kontejner3.appendChild(label);
const zaposli=document.createElement("button");
zaposli.innerHTML="Zaposli lekara";
kontejner3.appendChild(zaposli);
zaposli.onclick=(ev)=>{
    let ime=kontejner3.querySelector(".lekarIme").value;
    let prezime=kontejner3.querySelector(".lekarPrezime").value;
    let id=kontejner1.querySelector(".idBolnice").value;
    fetch("https://localhost:5001/Bolnica/UpisLekara/"+id,{
    method:"POST",
    headers:{
        "Content-Type":"application/json"
    },
    body: JSON.stringify({
        ime:ime,
        prezime:prezime
    })
});
}