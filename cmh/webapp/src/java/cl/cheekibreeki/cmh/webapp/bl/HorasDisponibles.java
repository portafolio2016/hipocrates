package cl.cheekibreeki.cmh.webapp.bl;

import cl.cheekibreeki.cmh.lib.dal.entities.Bloque;
import java.util.ArrayList;
import java.util.Date;

public class HorasDisponibles {
    private ArrayList<HoraDisponible> horas;
    
    public HorasDisponibles(){
        this.horas = new ArrayList<>();
    }
    
    public HorasDisponibles(Date date, ArrayList<Bloque> bloques){
        this.horas = new ArrayList<>();
        for(Bloque bloque: bloques){
            this.horas.add(new HoraDisponible(date, bloque));
        }
    }
    
    /**
     * @return the horas
     */
    public ArrayList<HoraDisponible> getHoras() {
        return horas;
    }

    /**
     * @param horas the horas to set
     */
    public void setHoras(ArrayList<HoraDisponible> horas) {
        this.horas = horas;
    }
}
