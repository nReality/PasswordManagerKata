import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.security.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.nio.file.Path;

public class PasswordManager
{

  public static void main(String[] args)
  {
    AddOrChangePassword();
    CheckPassword();
    System.console().readLine();
  }

  public static void AddOrChangePassword()
  {
    //input user name
    System.out.println("Enter your user name");
    String username = System.console().readLine();

    if (username == null || username.length() == 0)
    {
        System.out.println("User name cannot be empty. Try again.");
        //try again
        AddOrChangePassword();
        return;
    }

    //input password
    System.out.println("Enter your new password:");
    String password = System.console().readLine();

    //Validate password criteria

    if (password == null || password.length() == 0)
    {
        System.out.println("Password cannot be empty. Try again.");
        //try again
        AddOrChangePassword();
        return;
    }
    else if (password.length() < 6)
    {
        System.out.println("Should be at least 6 chars. Try again.");
        //try again
        AddOrChangePassword();
        return;
    }

    //Calculate hash
    MessageDigest md = null;
    try{
      md = MessageDigest.getInstance("MD5");
    } catch ( NoSuchAlgorithmException ex ) {
      throw new IllegalStateException( ex );
    }
    byte[] hash = null;
    try{
      hash = md.digest(password.getBytes("UTF-8"));//MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
    } catch ( java.io.UnsupportedEncodingException ex ) {
      throw new IllegalStateException( ex );
    }

    //Save password
    try {
      FileOutputStream stream = new FileOutputStream(username);
      try {
        stream.write(hash);
        stream.close();
      }catch ( IOException inner ) {
        throw new IllegalStateException( inner );
      }
    } catch ( java.io.FileNotFoundException ex ) {
      throw new IllegalStateException( ex );
    }
  }

  public static void CheckPassword()
  {
    //input user name and password
    System.out.println("Enter your user name");
    String username = System.console().readLine();
    System.out.println("Enter your password:");
    String password = System.console().readLine();

    //Calculate hash
    MessageDigest md = null;
    try{
      md = MessageDigest.getInstance("MD5");
    } catch ( NoSuchAlgorithmException ex ) {
      throw new IllegalStateException( ex );
    }
    byte[] hash = null;
    try{
      hash = md.digest(password.getBytes("UTF-8"));//MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
    } catch ( java.io.UnsupportedEncodingException ex ) {
      throw new IllegalStateException( ex );
    }

    byte[] savedHash = null;

    try
    {
        savedHash = Files.readAllBytes(new File(username).toPath());
    }
    catch (Exception ex)
    { /*gulp*/}

    if (hash == null || savedHash == null || java.util.Arrays.equals(savedHash, hash))
    {
        System.out.println("Correct password");
    }
    else
    {
        System.out.println("Incorrect password");
    }
  }

}
