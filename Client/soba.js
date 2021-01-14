export class Soba{
    constructor(id,brojSobe,odelenje,maxPrimljeni)
    {
        this.id=id;
        this.brojSobe=brojSobe;
        this.odelenje=odelenje;
        this.boja=this.odelenje.value;
        this.primljeni=0;
        this.maxPrimljeni=maxPrimljeni;
        this.miniKont1=null;
        this.pacijenti="";
        this.hitno=false;
    }
    dodajPacijenta(imeprezime)
    {
        this.pacijenti+=" "+imeprezime;
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
    azurirajSobu(imeprezime,odelenje,hitno){
        if(imeprezime=="")
        {
            this.pacijenti="";
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
                this.dodajPacijenta(imeprezime);
                this.odelenje=odelenje;
                this.primljeni++;
                this.bojaSobe=odelenje;
                this.miniKont1.innerHTML="Soba broj:"+this.brojSobe+" \nPacijenti:\n"+this.pacijenti+"\n"+"Ukupno u sobi:\n"+this.primljeni;
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