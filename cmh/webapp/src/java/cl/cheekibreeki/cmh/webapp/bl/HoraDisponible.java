package cl.cheekibreeki.cmh.webapp.bl;

/**
 *
 * @author palan
 */
public class HoraDisponible {
    private int  hora;

    public HoraDisponible(){
        this.hora = 0;
    }
    
    public HoraDisponible(int _hora){
        this.hora = _hora;
    }
    
    /**
     * @return the hora
     */
    public int getHora() {
        return hora;
    }

    /**
     * @param hora the horaInicio to set
     */
    public void setHora(int hora) {
        this.hora = hora;
    }
    
}
