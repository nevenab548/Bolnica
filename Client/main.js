import {Bolnica} from "./bolnica.js"

const kontejner1 = document.createElement("div");
kontejner1.className="main";
document.body.appendChild(kontejner1);
let label=document.createElement("label");
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
location.reload();
}
label = document.createElement("br");
kontejner1.appendChild(label);
label=document.createElement("label");
label.innerHTML="Uneti ID bolnice: ";
kontejner1.appendChild(label);
input = document.createElement("input");
input.className="id1";
input.type="number";
kontejner1.appendChild(input);
label = document.createElement("br");
kontejner1.appendChild(label);
const izbrisi=document.createElement("button");
izbrisi.innerHTML="Izbrisi bolnicu";
kontejner1.appendChild(izbrisi);
izbrisi.onclick=(ev)=>{
    let id=document.querySelector(".id1").value;
    fetch("https://localhost:5001/Bolnica/IzbrisiBolnicu?id="+id,{method:"DELETE"});
    location.reload();
}
fetch("https://localhost:5001/Bolnica/PreuzmiBolnice").then(p=>{
    p.json().then(data=>{
        data.forEach(bolnica => {
           const bolnica1=new Bolnica(bolnica.naziv,bolnica.brojSoba,bolnica.kapacitetSobe,bolnica.uSmeni);
            bolnica1.crtajBolnicu(document.body);

            bolnica.sobe.forEach(soba=>{
                var s=bolnica1.sobe[soba.brojSobe-1];
                if(soba.maxPrimljeni>=soba.primljeni+s.primljeni)
                {
                    s.azurirajSobu(soba.pacijenti,soba.odelenje,soba.hitno);
                }
            });

            bolnica.smene.forEach(smena=>{
                var s=bolnica1.smene[smena.broj-1];
                    s.azurirajSmenu(smena.lekar,smena.brojSmene);
            });

            bolnica1.lekari.forEach(lekar=>{
                bolnica1.dodajLekara(lekar);
            })
        });
    });
});
