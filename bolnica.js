import {Soba} from "./soba.js"
import {Smena} from "./smena.js"

export class Bolnica{
    constructor(naziv,brojSoba,kapacitetSobe,uSmeni)
    {
        this.naziv=naziv;
        this.brojSoba=brojSoba;
        this.kapacitetSobe=kapacitetSobe;
        this.uSmeni=uSmeni;
        this.sobe=[];
        this.smene=[];
        this.kontejner=null;
        this.kontejner2=null;
    }
    dodajSmenu(lekar)
    {
        this.smene.push(lekar);
    }
    dodajSobu(soba)
    {
        this.sobe.push(soba);
    }
    crtajBolnicu(host)
    {
        if(!host)
        {
            throw new Error("Host ne postoji!");
        }
        const naziv=document.createElement("h1");
        naziv.innerHTML=this.naziv;
        host.appendChild(naziv);
        this.kontejner=document.createElement("div");
        this.kontejner.className="kontejner";
        host.appendChild(this.kontejner);
        this.crtajFormuSoba(this.kontejner);
        this.crtajSobe(this.kontejner);
        this.kontejner2=document.createElement("div");
        this.kontejner2.className="kontejner";
        host.appendChild(this.kontejner2);
        this.crtajFormuSmena(this.kontejner2);
        this.crtajSmene(this.kontejner2);
    }
    crtajFormuSoba(host)
    {
        const kont1 = document.createElement("div");
        kont1.className="kont1";
        host.appendChild(kont1);

        let divO=document.createElement("div");
        let image=document.createElement("img");
        image.src="cross.jpg";
        divO.appendChild(image);
        let elLabela1=document.createElement("h3");
        elLabela1.innerHTML="Prijem pacijenata";
        divO.appendChild(elLabela1);

        kont1.appendChild(divO);

        elLabela1=document.createElement("label");
        elLabela1.innerHTML="Ime pacijenta:";
        kont1.appendChild(elLabela1);

        let unos = document.createElement("input");
        unos.className="ime";
        kont1.appendChild(unos);

        elLabela1=document.createElement("label");
        elLabela1.innerHTML="Prezime pacijenta:";
        kont1.appendChild(elLabela1);

        unos = document.createElement("input");
        unos.className="prezime";
        kont1.appendChild(unos);

        elLabela1=document.createElement("br");
        kont1.appendChild(elLabela1);

        elLabela1=document.createElement("label");
        elLabela1.innerHTML="Odelenje na koje se smešta:";
        kont1.appendChild(elLabela1);
        let odelenja=["Pulmologija","Kardiologija","Hirurgija","Ortopedija","Onkologija"];
        let boje=["blue","brown","red","green","purple"];
        let opcija=null;
        let labela=null;
        odelenja.forEach((odelenje,ind)=>{
            divO = document.createElement("div");
            divO.className="odelenja";
            opcija=document.createElement("input");
            opcija.type="radio";
            opcija.name=this.naziv;
            opcija.value=boje[ind];
    
            labela =document.createElement("label");
            labela.innerHTML=odelenje;
            labela.style.color=boje[ind];
    
            divO.appendChild(opcija);
            divO.appendChild(labela);
            divO.classList.add(odelenje);
            kont1.appendChild(divO);
        })

        elLabela1=document.createElement("br");
        kont1.appendChild(elLabela1);

        divO=document.createElement("div");
        elLabela1=document.createElement("label");
        elLabela1.innerHTML="Hitan slučaj:";
        divO.appendChild(elLabela1);
        unos = document.createElement("input");
        unos.type="checkbox";
        unos.name="hitno";
        divO.appendChild(unos);
        divO.classList.add("hitno")
        kont1.appendChild(divO);
        
        elLabela1=document.createElement("br");
        kont1.appendChild(elLabela1);

        divO=document.createElement("div");
        elLabela1=document.createElement("label");
        elLabela1.innerHTML="Broj sobe:";
        divO.appendChild(elLabela1);
        unos = document.createElement("select");
        divO.appendChild(unos);
        for(let i=0;i<this.brojSoba;i++)
        {
            opcija = document.createElement("option");
            opcija.innerHTML=i+1;
            opcija.value=i+1;
            unos.appendChild(opcija);
        }
        kont1.appendChild(divO);

        elLabela1=document.createElement("br");
        kont1.appendChild(elLabela1);

        const dugme=document.createElement("button");
        dugme.innerHTML="Smestiti pacijenta";
        kont1.appendChild(dugme);
        dugme.onclick=(ev)=>{
            let ime=this.kontejner.querySelector(".ime").value;
            let prezime=this.kontejner.querySelector(".prezime").value;
            let odelenje=this.kontejner.querySelector(`input[name=${this.naziv}]:checked`).value;
            let hitno=this.kontejner.querySelector(`input[name="hitno"]`).checked;
            if(odelenje==null)
            alert("Molimo Vas izaberite odelenje na koje se prima pacijent!");
            let brSobe=parseInt(unos.value);
            if(this.sobe[brSobe-1].hitno==true && hitno==false)
            alert("Ovo je soba intenzivne nege! Molimo Vas smestite pacijenta u drugu.");
            else if(this.sobe[brSobe-1].odelenje!=odelenje && this.sobe[brSobe-1].primljeni>0)
            alert("Ova soba pripada drugom odelenju! Izaberite drugu.");
            else {let mogucaSoba=this.sobe.find(s=>s.odelenje==odelenje && s.primljeni+1<=s.maxPrimljeni && s.brojSobe!=brSobe && s.hitno==hitno);
            if(mogucaSoba)
            alert("Postoji nepopunjena soba! Soba je broj "+mogucaSoba.brojSobe+".");
            else
            this.sobe[brSobe-1].azurirajSobu(ime,prezime,odelenje,hitno);
            }
        }
        elLabela1=document.createElement("br");
        kont1.appendChild(elLabela1);
        elLabela1=document.createElement("br");
        kont1.appendChild(elLabela1);

        divO=document.createElement("div");
        divO.className="oslobodi";
        elLabela1=document.createElement("label");
        elLabela1.innerHTML="Uneti broj sobe"
        divO.appendChild(elLabela1);
        elLabela1=document.createElement("input");
        elLabela1.name="oslobodi"
        elLabela1.type="number";
        divO.appendChild(elLabela1);
        const dugme2=document.createElement("button");
        dugme2.innerHTML="Osloboditi sobu";
        divO.appendChild(dugme2);
        dugme2.onclick=(ev)=>{
            let broj=document.querySelector(`input[name="oslobodi"]`).value;
            if(!this.sobe[broj-1])
            alert("Soba ne postoji!");
            else if(this.sobe[broj-1].primljeni==0)
            alert("Soba je vec prazna!");
            else
            {
            this.sobe[broj-1].azurirajSobu("","","",false);
            }   
        }
        kont1.appendChild(divO);

    }
    crtajSobe(host)
    {
        const kontSobe=document.createElement("div");
        kontSobe.className="kontSobe";
        host.appendChild(kontSobe);
        let soba;
        for(let i=0;i<this.brojSoba;i++)
        {
            soba=new Soba(i+1,"",this.kapacitetSobe);
            this.dodajSobu(soba);
            soba.crtajSobu(kontSobe);
        }
    }
    crtajFormuSmena(host)
    {
        const kont2 = document.createElement("div");
        kont2.className="kont2";
        host.appendChild(kont2);

        let divO=document.createElement("div");
        let image=document.createElement("img");
        image.src="cross.jpg";
        divO.appendChild(image);
        let elLabela1=document.createElement("h3");
        elLabela1.innerHTML="Raspored lekara";
        divO.appendChild(elLabela1);
        kont2.appendChild(divO);

        elLabela1=document.createElement("label");
        elLabela1.innerHTML="Ime lekara:";
        kont2.appendChild(elLabela1);

        let unos = document.createElement("input");
        unos.className="ime";
        kont2.appendChild(unos);

        elLabela1=document.createElement("label");
        elLabela1.innerHTML="Prezime lekara:";
        kont2.appendChild(elLabela1);

        unos = document.createElement("input");
        unos.className="prezime";
        kont2.appendChild(unos);

        elLabela1=document.createElement("br");
        kont2.appendChild(elLabela1);

        const dugme=document.createElement("button");
        dugme.innerHTML="Zaposliti lekara";
        kont2.appendChild(dugme);
        
        dugme.onclick=(ev)=>{
            let ime=this.kontejner2.querySelector(".ime").value;
            let prezime=this.kontejner2.querySelector(".prezime").value;
            let pom=document.createElement("option");
            pom.text=ime+" "+prezime;
            select=this.kontejner2.querySelector(".selekt");
            select.appendChild(pom);
        }

        elLabela1=document.createElement("br");
        kont2.appendChild(elLabela1);
        elLabela1=document.createElement("br");
        kont2.appendChild(elLabela1);

        elLabela1=document.createElement("label");
        elLabela1.innerHTML="Izabrati lekara za smenu:";
        kont2.appendChild(elLabela1);
        let lekari=["Marko Dimitrijevic","Ana Lekic","Danica Mirkovic","Lazar Zivkovic","Damir Markovic","Tijana Vasic"];
        let opcija=null;
        let labela=null;
        let select=document.createElement("select");
        select.className="selekt";
        lekari.forEach((lekar,ind)=>{
            divO = document.createElement("div");
            divO.className="lekar";
            opcija=document.createElement("option");
            opcija.name=this.naziv;
            opcija.text=lekar;
    
            select.appendChild(opcija);
            divO.appendChild(select);
            kont2.appendChild(divO);
        })

        divO=document.createElement("div");
        elLabela1=document.createElement("label");
        elLabela1.innerHTML="Broj smene:";
        divO.appendChild(elLabela1);
        unos = document.createElement("select");
        divO.appendChild(unos);
        for(let i=0;i<2;i++)
        {
            opcija = document.createElement("option");
            opcija.innerHTML=i+1;
            opcija.value=i+1;
            unos.appendChild(opcija);
        }
        kont2.appendChild(divO);

        elLabela1=document.createElement("br");
        kont2.appendChild(elLabela1);
        divO=document.createElement("div");
        elLabela1=document.createElement("label");
        elLabela1.innerHTML="Mesto po rasporedu:";
        divO.appendChild(elLabela1);
        let unos2 = document.createElement("select");
        divO.appendChild(unos2);
        for(let i=0;i<this.uSmeni;i++)
        {
            opcija = document.createElement("option");
            opcija.innerHTML=i+1;
            opcija.value=i+1;
            unos2.appendChild(opcija);
        }
        kont2.appendChild(divO);

        elLabela1=document.createElement("br");
        kont2.appendChild(elLabela1);

        const dugme2=document.createElement("button");
        dugme2.innerHTML="Rasporediti";
        kont2.appendChild(dugme2);
        dugme2.onclick=(ev)=>{
            let lekar=this.kontejner2.querySelector(".selekt").value;
            let brSmene=parseInt(unos.value);
            let mesto=parseInt(unos2.value);
            this.smene[mesto-1].azurirajSmenu(lekar,brSmene);
            }
    }
    crtajSmene(host)
    {
        const kontSmene=document.createElement("div");
        kontSmene.className="kontSmene";
        host.appendChild(kontSmene);
        let smena;
        for(let i=0;i<this.uSmeni;i++)
        {
            smena=new Smena(1);
            this.dodajSmenu(smena);
            smena.crtajSmenu(kontSmene);
        }
    }
}