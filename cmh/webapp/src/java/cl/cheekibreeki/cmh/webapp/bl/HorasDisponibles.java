package cl.cheekibreeki.cmh.webapp.bl;

import java.util.ArrayList;

public class HorasDisponibles {
    private ArrayList<Integer> horas;

    public HorasDisponibles(){
        this.horas = new ArrayList<>();
    }
    
    /**
     * @return the horas
     */
    public ArrayList<Integer> getHoras() {
        return horas;
    }

    /**
     * @param horas the horas to set
     */
    public void setHoras(ArrayList<Integer> horas) {
        this.horas = horas;
    }
}
