/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cl.cheekibreeki.cmh.webapp.util;

import java.io.UnsupportedEncodingException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Arrays;

/**
 *
 * @author pdelasotta
 */
public class PassHasher {
    public static String hashToMD5(String str){
        try {
            byte[] passBytes = str.getBytes("UTF-8");
            MessageDigest md = MessageDigest.getInstance("MD5");
            byte[] hashedPassBytes = md.digest(passBytes);
            String hashedPass = Arrays.toString(hashedPassBytes);
            return hashedPass;
        } catch (Exception e) {//si algo falla
            System.out.println(e.getMessage());
            return "";
        }
    }
}
