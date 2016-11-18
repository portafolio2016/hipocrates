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

    public static String hashToMD5(String str) {
        try {
            byte[] passBytes = str.getBytes("UTF-8");
            MessageDigest md = MessageDigest.getInstance("MD5");
            byte[] hashedPassBytes = md.digest(passBytes);
            String hashedPass = bytesToHex(hashedPassBytes);
            return hashedPass;
        } catch (Exception e) {//si algo falla
            System.out.println(e.getMessage());
            return "";
        }
    }

    final protected static char[] hexArray = "0123456789ABCDEF".toCharArray();
    public static String bytesToHex(byte[] bytes) {
        char[] hexChars = new char[bytes.length * 2];
        for (int j = 0; j < bytes.length; j++) {
            int v = bytes[j] & 0xFF;
            hexChars[j * 2] = hexArray[v >>> 4];
            hexChars[j * 2 + 1] = hexArray[v & 0x0F];
        }
        return new String(hexChars);
    }
}
