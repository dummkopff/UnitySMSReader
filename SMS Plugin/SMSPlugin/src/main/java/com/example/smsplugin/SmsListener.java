package com.example.smsplugin;

import android.content.Context;
import android.content.Intent;
import android.widget.Toast;
import com.unity3d.player.UnityPlayer;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import com.example.smsplugin.Sms;
import com.example.smsplugin.TelephonyProvider;
import android.telephony.SmsMessage;

public class SmsListener {
    public static void onReceive(String message)
    {
        Context context = UnityPlayer.currentActivity;
        TelephonyProvider telephonyProvider = new TelephonyProvider(context);
        List<Sms> sms = telephonyProvider.getSms(TelephonyProvider.Filter.ALL).getList();
        String builder = "";

        int k = sms.size()-1;
        if (sms.size() > 0)
        {
            while (k >= 0)
            {
                if (sms.get(k).address.equals(message))
                {
                    SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
                    Date date = new Date(sms.get(k).receivedDate);
                    builder +=  sms.get(k).body + "&" + format.format(date) + "|";
                }
                k -= 1;
            }
        }
        else { builder = "SMS Inbox is empty"; }
        //Toast.makeText(UnityPlayer.currentActivity, "SMS Reader!", Toast.LENGTH_SHORT).show();
        UnityPlayer.UnitySendMessage("UnitySMSReader", "GetSMS", builder.substring(0,builder.length() -1));
    }
}
