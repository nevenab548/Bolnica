export class Soba{
    constructor(brojSobe,odelenje,maxPrimljeni)
    {
        this.brojSobe=brojSobe;
        this.odelenje=odelenje;
        this.boja=this.odelenje.value;
        this.primljeni=0;
        this.maxPrimljeni=maxPrimljeni;
        this.miniKont1=null;
        this.pacijenti=[];
        this.hitno=false;
    }
    dodajPacijenta(ime,prezime)
    {
        let p=ime+" "+prezime+"\n";
        this.pacijenti.push(p);
    }
    vratiBoju()
    {
        if(this.bojaSobe==null)
        return "lightblue";
        else
        return this.bojaSobe;
    }
    crtajSobu(host)
    {
        this.miniKont1=document.createElement("div");
        this.miniKont1.className="soba";
        this.miniKont1.innerHTML="Soba broj "+this.brojSobe+"\n slobodna";
        this.miniKont1.style.backgroundColor=this.vratiBoju();
        host.appendChild(this.miniKont1);
    }
    azurirajSobu(ime,prezime,odelenje,hitno){
        if(ime=="" && prezime=="")
        {
            this.pacijenti=[];
            this.primljeni=0;
            this.bojaSobe=null;
            this.miniKont1.innerHTML="Soba broj "+this.brojSobe+"\n slobodna";
            this.miniKont1.style.backgroundColor=this.vratiBoju();
        }
        else
        {
        this.hitno=hitno;
        if(this.primljeni+1>this.maxPrimljeni)
            alert("Kapacitet je popunjen!");
        else
            {
                this.dodajPacijenta(ime,prezime);
                this.odelenje=odelenje;
                this.primljeni++;
                this.bojaSobe=odelenje;
                this.miniKont1.innerHTML=this.brojSobe+" "+this.pacijenti+" , "+this.primljeni;
                this.miniKont1.style.backgroundColor=this.vratiBoju();
                    if(this.hitno==true)
                    {
                        this.miniKont1.innerHTML+="\nINTENZIVNA NEGA";
                        this.miniKont1.style.backgroundColor="limegreen";
                    }
            }
        if(this.primljeni==this.maxPrimljeni)
            this.miniKont1.style.backgroundColor="yellow";
        }
        }
}