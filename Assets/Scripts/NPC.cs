using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour
{
    [SerializeField] string[] mainDialogueMessages; //initial messages to relay to player
    [SerializeField] string[] extraDialogue; //messages to relay to player after main dialogue
	//in unity, these will initially show as drop downs with a Size parameter
	//fill the Size parameter with the number of messages and then hit enter and you will have
	//multiple slots to place each individual message
    [SerializeField] private Text message; //lets you fill this manually in editor if you have a
    //message box or whatever
	
    [SerializeField] bool useCI, useCIFill, useCIColor, useCIFlash;
    //you don't HAVE to use the continue indicator if you don't want to...
    //features are totally optional
	
	//useCIFill will make the continue indicator "fill" radially as the message types out

    [SerializeField] private Image continueIndicator; //FILL THIS IF YOU WANT TO USE IT
    //continue indicator - its that little thing at the bottom of message boxes 
    //that pops up when the dialogue is completed and you can hit the button to continue
    //to use: Image's "Image Type" dropdown must be set to "Filled" then drag the Image into this slot
    //note: Image is a UI Element
    
    [SerializeField] Color contIndIncompleteColor, contIndCompleteColor; //FILL THESE IF YOU WANT DIFFERENT COLORS
    //you can use this to change the color the indicator is while message is incomplete
    //color will change to "complete color" when the message is finished and you can hit
    //fire1 to continue
    //by default it'll use white

	[SerializeField] bool useCharDelay; //leave unchecked to display each message all at once
    [SerializeField] float charDelay; //delay between characters displayed in message
	//holding Fire2 (right-click) will bypass the delay make it effectively 0
    [SerializeField] float CIFlashDelay; //FILL THIS IF YOU WANT THE INDICATOR TO FLASH WHEN DONE
	//interval on which the continue indicator flashes if enabled

    private bool notHit;
    private Queue<string> messageQueue;
    private WaitForSeconds _cd, _cifd;

    void Start()
    {
        //Create Text component of a canvas object through unity named "Message"
        if(message==null) message = GameObject.Find("Message").GetComponent<Text>();
		//if you didn't fill the continue indicator, the script will bypass all of the extras
        if(continueIndicator==null) useCI=useCIFill=useCIColor=useCIFlash=false;
        //message.color = Color.white;
        _cd = new WaitForSeconds(charDelay); //premake the delays so we don't need to make new WaitForSeconds constantly
        _cifd = new WaitForSeconds(CIFlashDelay);
        messageQueue = new Queue<string>();
        notHit=true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Messages to display for main dialogue
        if (other.gameObject.tag == "Player" && notHit){
            for(int i=0; i<mainDialogueMessages.Length;++i) { //use a queue structure for sequential messages
                messageQueue.Enqueue(mainDialogueMessages[i]);
            }
            StartCoroutine(displayText(other));
        }
        //Messages to display if main dialogue is done
        else if(other.gameObject.tag == "Player" && !notHit){
            for(int i=0; i<extraDialogue.Length;++i) {
                messageQueue.Enqueue(extraDialogue[i]);
            }
            StartCoroutine(displayText(other));
        }
    }
    IEnumerator displayText(Collider2D other)
    {
		//disable player movement
        //other.gameObject.GetComponent<Player_Move_Update>().playerSpeed = 0;
        while(messageQueue.Count>0){ //main loop will go through all the messages in the queue
            string s = messageQueue.Dequeue();
            float fillStep = 1f/((float)s.Length); //used for CIFill option
            if(useCI){
                continueIndicator.fillAmount = 0f;
                if(useCIColor) continueIndicator.color = contIndIncompleteColor;
                else continueIndicator.color = Color.white;
            }
            message.text=""; //initialize message text as blank
            if(useCharDelay){
                for(int i=0; i<s.Length; ++i){ //sequentially add each character in the message to the text
                    message.text += s[i]; 
                    if(useCI && useCIFill) continueIndicator.fillAmount+=fillStep;
                    if(!Input.GetButton("Fire2")) yield return _cd; //this is the code for holding Fire2 to 
                    else yield return null; //speed message up
                }
            }
            else {
                message.text=s;            
                if(useCI&&useCIFill) continueIndicator.fillAmount = 1f;
            }
            if(useCI && useCIColor) continueIndicator.color= contIndCompleteColor;
            if(useCI && !useCIFill) continueIndicator.fillAmount=1f;
            bool flip=false; float nextFlip = Time.time + CIFlashDelay; //used for flashing effect
            while(!Input.GetButtonDown("Fire1")){ //wait for input loop
                if(useCIFlash&&Time.time > nextFlip){ //flashing effect, indicator flips between its color and clear every intervl
                    if(flip) continueIndicator.color = 
                    (useCIColor?contIndCompleteColor:Color.white);
                    else continueIndicator.color = Color.clear;
                    flip=!flip;
                    nextFlip=Time.time+CIFlashDelay;
                }
                yield return null;
            }
            yield return new WaitForEndOfFrame(); //this is essential, it ensures that one input isn't used for all of the messages
			//a while loop is much faster than a frame
        }
        
        //let player move again
        //other.gameObject.GetComponent<Player_Move_Update>().playerSpeed = 5;
        notHit=false;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            message.text = "";
			if(useCI){ //if you had a continue indicator, this will turn it off upon leaving
				continueIndicator.fillAmount = 0f;
				continueIndicator.color= contIndIncompleteColor;
			}
        }
    }
}
