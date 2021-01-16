export class Smena{
    constructor(id,brojSmene,broj)
    {
        this.id=id;
        this.brojSmene=brojSmene; //2 - nocna,1 - dnevna
        this.broj=broj;
        this.lekar=null;
        this.boja=this.vratiBoju();
    }
    dodajLekara(imeprezime)
    {
        this.lekar= imeprezime;
    }
    vratiBoju()
    {
        if(this.lekar==null)
        return "lightpink";
        else if(this.brojSmene==1)
        return "mediumspringgreen";
        else if(this.brojSmene==2)
        return "orange";
    }
    crtajSmenu(host)
    {
        this.miniKont1=document.createElement("div");
        this.miniKont1.className="smena";
        this.miniKont1.innerHTML="Smena "+this.broj;
        this.miniKont1.style.backgroundColor=this.vratiBoju();
        host.appendChild(this.miniKont1);
    }
    azurirajSmenu(lekar,brojSmene){
        if(lekar==null)
        {
            brojSmene=0;
            this.miniKont1.innerHTML="";
            this.miniKont1.style.backgroundColor=this.vratiBoju();
        }
        else
        {
        this.brojSmene=brojSmene;
        this.dodajLekara(lekar);
        if(brojSmene==1)
        this.miniKont1.innerHTML=this.lekar+" - dnevna smena";
        else
        this.miniKont1.innerHTML=this.lekar+" - nocna smena";
        this.miniKont1.style.backgroundColor=this.vratiBoju();
        }
        }
}