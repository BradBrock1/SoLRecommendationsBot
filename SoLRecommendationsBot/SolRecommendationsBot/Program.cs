using System;
using System.Collections.Generic;
using System.Linq;
using RedditSharp.Things;
using RedditSharp;

/*
 * 
 * 	RedditSharp is developed by SirCmpwn. 
 * 
 *  SoLRecommendationsBot is developed by BradBrock1 (/u/genericthrowawayyes)
 *  This program is open-source. According to the license set by SirCmpwn and myself, this program may be
 *  modified, redistributed and used commercially, as long as credit is given to both SirCmpwn and myself.
 *  
 *  Note to editors:
 * 			The source code is pretty easy to understand. I've commented on a few things here and there in case you aren't 
 * 			familiar with RedditSharp's API. 
 * 		
 * 			Feel free to edit this to your hearts content and use it as your own bot.
 * 			If you want to improve this product but not use it as your own bot, and improve upon the original, you can do so
 * 			by using GitHub, or PM'ing me on reddit. http://www.reddit.com/user/genericthrowawayyes
 * 
 */ 

namespace SoLRecommendationBot
{
	class MainClass
	{
		static Reddit reddit = null;
		static string username = null;
		public static void Main (string[] args)
		{
			bool isAuthed = false;
			while (!isAuthed)
			{
				Console.Write ("Username: ");
				username = Console.ReadLine ();
				Console.Write ("Password: ");
				string password = ReadPassword ();
				try
				{
					Console.Write("\nLogging In... ");
					reddit = new Reddit(username,password);
					isAuthed = reddit.User != null;
					Console.Clear();
					Console.Write("Successfully Logged In. Welcome "+username+"\nStarted @ "+DateTime.Now.ToLocalTime().ToShortTimeString()+"\n");
				}
				catch(Exception ex) 
				{
					Console.Write (ex.Message+"\nPress enter to exit...");
					Console.Read ();
					Environment.Exit (0);
				}
				/*
				 * Is logged in from here
				 */
				postComment ();
			}
		}
		public static void postComment()
		{
			var subreddit = reddit.GetSubreddit ("/r/anime"); //Here you can change the subreddit and what-not
			int count = 0, counters = 30; 
			// Count is how many threads there are that match the description
			// Counters is how many threads should be searched
			foreach (var post in subreddit.New.Take(counters))  //For each post in the subreddit
			{
				if (post.SelfText.ToLower().Contains ("slice of life")&&post.SelfText.ToLower().Contains("recommendation")||post.SelfText.ToLower().Contains ("sol")&&post.SelfText.ToLower().Contains("recommendation")||post.SelfText.ToLower().Contains ("sol")&&post.SelfText.ToLower().Contains("recommend me")||post.SelfText.ToLower().Contains ("slice of life")&&post.SelfText.ToLower().Contains("recommend me")) 
					//This line checks the text that is bundled with the post and sees if it contains the keywords needed to trigger the bot
				{
					bool post1 = true;
					for (int i = 0; i < post.CommentCount; i++) 
					{
						if (post.Comments [i].Author == username) //Goes through each comment and checks the author.
							//If one of the comments has an author which is the bot, it won't post.
						{
							post1 = false;
						}
					}
					if (post1) 
					{
						count++; //Add 1 to count everytime a thread matches the keywords and hasn't been commented on by the bot
						try 
						{
							//Posts the predetermined comment
							post.Comment ("Hello " + post.AuthorName + "!\nYou seem to be looking for some Slice of Life recommendations!\nHere is a list: \n\n* **[A-channel.](http://myanimelist.net/anime/9776/A-Channel)**\n* **[Acchi Kocchi.](http://myanimelist.net/anime/12291/Acchi_Kocchi_(TV)**\n* **[Aiura.](http://myanimelist.net/anime/17082/Aiura)**\n* **[Aria.](http://myanimelist.net/anime/477/Aria_The_Animation)**\n* **[Azumanga Daioh!](http://myanimelist.net/anime/66/Azumanga_Daioh)**\n* **[Baka no test to shoukanju.](http://myanimelist.net/anime/6347/Baka_to_Test_to_Shoukanjuu)**\n* **[Bamboo blade.](http://myanimelist.net/anime/2986/Bamboo_Blade)**\n* **[Binchou-tan.](http://myanimelist.net/anime/750/Binchou-tan)**\n* **[Binzume Yousei.](http://myanimelist.net/anime/348/Binzume_Yousei)**\n* **[Choboraunyopomi Gekijou Ai Mai Mii.](http://myanimelist.net/anime/16169/Choboraunyopomi_Gekijou_Ai_Mai_Mii)**\n* **[Choujigen Game Neptune The Animation.](http://myanimelist.net/anime/16157/Choujigen_Game_Neptune_The_Animation)**\n* **[Chuunibyou demo koi ga shitai!](http://myanimelist.net/anime/14741/Chuunibyou_demo_Koi_ga_Shitai!)**\n* **[D-frag.](http://myanimelist.net/anime/20031/D-Frag!)**\n* **[Danshi Koukousei no nichijou.](http://myanimelist.net/anime/11843/Danshi_Koukousei_no_Nichijou)**\n* **[Double J.](http://myanimelist.net/anime/10838/Double-J)**\n* **[Futsuu no Joshikousei ga [Locodol] Yatte Mita.](http://myanimelist.net/anime/22189/Futsuu_no_Joshikousei_ga_[Locodol]_Yatte_Mita.)**\n* **[Fuujin Monogatari.](http://myanimelist.net/anime/1524/Fuujin_Monogatari)**\n* **[G.A: Geijutsuka Art design class.](http://myanimelist.net/anime/5670/GA:_Geijutsuka_Art_Design_Class)**\n* **[GJ-BU.](http://myanimelist.net/anime/14811/GJ-bu)**\n* **[Gakuen Utopia Manabi Straight!](http://myanimelist.net/anime/1858/Gakuen_Utopia_Manabi_Straight!)**\n* **[Galaxy Angel.](http://myanimelist.net/anime/383/Galaxy_Angel)**\n* **[Gekkan Shoujo Nozaki-kun.](http://myanimelist.net/anime/23289/Gekkan_Shoujo_Nozaki-kun)**\n* **[Girl friend (Kari).](http://myanimelist.net/anime/24855/Girlfriend_(Kari)**\n* **[Girls und Panzer](http://myanimelist.net/anime/14131/Girls_und_Panzer)**\n* **[Gochuumon Usagi wa desu ka?](http://myanimelist.net/anime/21273/Gochuumon_wa_Usagi_Desu_ka)**\n* **[Gokujo: Gokurakuin Joshikou Ryou Monogatari.](http://myanimelist.net/anime/11769/Gokujo.:_Gokurakuin_Joshikou_Ryou_Monogatari?q=goku)**\n* **[Hanasaku Iroha.](http://myanimelist.net/anime/9289/Hanasaku_Iroha)**\n* **[Hanayamata.](http://myanimelist.net/anime/21681/Hanayamata)**\n* **[Happiness!](http://myanimelist.net/anime/1570/Happiness!)**\n* **[Hibike! Euphonium.](http://myanimelist.net/anime/27989/Hibike!_Euphonium)**\n* **[Hidamari Sketch.](http://myanimelist.net/anime/1852/Hidamari_Sketch)**\n* **[Himouto! Umaru-chan.](http://myanimelist.net/anime/28825/Himouto!_Umaru-chan)**\n* **[Hyakko.](http://myanimelist.net/anime/4550/Hyakko)**\n* **[Ichigo Mashimaro.](http://myanimelist.net/anime/488/Ichigo_Mashimaro)**\n* **[Ikoku Meiro No Croisee.](http://myanimelist.net/anime/9938/Ikoku_Meiro_no_Crois%C3%A9e)**\n* **[Inugami-san to Nekoyama-san.](http://myanimelist.net/anime/22123/Inugami-san_to_Nekoyama-san)**\n* **[Isshuukan Friends.](http://myanimelist.net/anime/21327/Isshuukan_Friends.)**\n* **[Jinsei.](http://myanimelist.net/anime/23121/Jinsei)**\n* **[Jitsu wa Watashi wa.](http://myanimelist.net/anime/29785/Jitsu_wa_Watashi_wa)**\n* **[Joshi Kousei: Girl's High](http://myanimelist.net/anime/863/Joshi_Kousei__Girls_High)**\n* **[Joshiraku.](http://myanimelist.net/anime/12679/Joshiraku)**\n* **[K-on.](http://myanimelist.net/anime/5680/K-On!)**\n* **[Kami Nomi zo shiru sekai.](http://myanimelist.net/anime/8525/Kami_nomi_zo_Shiru_Sekai)**\n* **[Kamichu!](http://myanimelist.net/anime/489/Kamichu!)**\n* **[Kiniro Mosaic.](http://myanimelist.net/anime/16732/Kiniro_Mosaic)**\n* **[Kitakubu Katsudou Kiroku.](http://myanimelist.net/anime/18495/Kitakubu_Katsudou_Kiroku)**\n* **[Kokoro Toshokan.](http://myanimelist.net/anime/799/Kokoro_Toshokan)**\n* **[Komori-san wa Kotowarenai!](http://myanimelist.net/anime/31091/Komori-san_wa_Kotowarenai!)**\n* **[Kotoura-san.](http://myanimelist.net/anime/15379/Kotoura-san)**\n* **[Koufuku Graffiti.](http://myanimelist.net/anime/24629/Koufuku_Graffiti)**\n* **[Kyou no Go no Ni.](http://myanimelist.net/anime/4903/Kyou_no_Go_no_Ni_(2008)**\n* **[Love Hina.](http://myanimelist.net/anime/189/Love_Hina)**\n* **[Love Lab!](http://myanimelist.net/anime/16353/Love_Lab)**\n* **[Lucky Star.](http://myanimelist.net/anime/1887/Lucky%E2%98%86Star)**\n* **[Mikakunin de Shinkoukei](http://myanimelist.net/anime/20541/Mikakunin_de_Shinkoukei)**\n* **[Minami-ke.](http://myanimelist.net/anime/2963/Minami-ke)**\n* **[Miyakawa-ke no Kuufuku.](http://myanimelist.net/anime/17637/Miyakawa-ke_no_Kuufuku)**\n* **[Monster Musume no Iru Nichijou.](http://myanimelist.net/anime/30307/Monster_Musume_no_Iru_Nichijou)**\n* **[Morita-san wa mukuchi.](http://myanimelist.net/anime/10671/Morita-san_wa_Mukuchi.)**\n* **[Moyashimon.](http://myanimelist.net/anime/3001/Moyashimon)**\n* **[Namiuchigiwa no Muromi-san.](http://myanimelist.net/anime/16910/Namiuchigiwa_no_Muromi-san)**\n* **[Nichijou.](http://myanimelist.net/anime/10165/Nichijou)**\n* **[Nisekoi.](http://myanimelist.net/anime/18897/Nisekoi)**\n* **[Non non biyori.](http://myanimelist.net/anime/17549/Non_Non_Biyori)**\n* **[Ooyasan wa Shishunki!](http://myanimelist.net/anime/31621/Ooyasan_wa_Shishunki!)**\n* **[Ore Monogatari!!](http://myanimelist.net/anime/28297/Ore_Monogatari!!)**\n* **[Oshiete! Galko-chan.](http://myanimelist.net/anime/32013/Oshiete!_Galko-chan)**\n* **[Osomatsu-san.](http://myanimelist.net/anime/31174/Osomatsu-san)**\n* **[Pita-ten!](http://myanimelist.net/anime/162/Pita_Ten)**\n* **[Plastic Nee-san.](http://myanimelist.net/manga/25675/Plastic_Neesan)**\n* **[Pupipo!](http://myanimelist.net/anime/21325/Pupipo!)**\n* **[Ranma 1/2.](http://myanimelist.net/anime/210/Ranma_%C2%BD)**\n* **[Renkin San-kyuu Magical? Pokaan](http://myanimelist.net/anime/941/Renkin_San-kyuu_Magical_Pokaan)**\n* **[Sakura Trick.](http://myanimelist.net/anime/20047/Sakura_Trick)**\n* **[Sasameki-koto.](http://myanimelist.net/anime/6203/Sasameki_Koto)**\n* **[School Rumble.](http://myanimelist.net/anime/24/School_Rumble)**\n* **[Seitokai Yakuindomo.](http://myanimelist.net/anime/8675/Seitokai_Yakuindomo)**\n* **[Seitokai no Ichizon.](http://myanimelist.net/anime/5909/Seitokai_no_Ichizon)**\n* **[Servant x Service](http://myanimelist.net/anime/18119/Servant_x_Service)**\n* **[Shirobako.](http://myanimelist.net/anime/25835/Shirobako)**\n* **[Show by Rock!!](http://myanimelist.net/anime/27441/Show_By_Rock)**\n* **[Sketchbook ~Full Color'S~.](http://myanimelist.net/anime/2942/Sketchbook:_Full_Colors)**\n* **[Sora no Method.](http://myanimelist.net/anime/23209/Sora_no_Method)**\n* **[Sora no Woto.](http://myanimelist.net/anime/6802/So_Ra_No_Wo_To)**\n* **[Sore Demo Machi wa Mawatteiru.](http://myanimelist.net/anime/8726/Soredemo_Machi_wa_Mawatteiru)**\n* **[Sore ga Seiyuu!](http://myanimelist.net/anime/29163/Sore_ga_Seiyuu!)**\n* **[Takamiya Nasuno Desu!: Teekyuu Spin-off](http://myanimelist.net/anime/28861/Takamiya_Nasuno_Desu__Teekyuu_Spin-off)**\n* **[Tamako Market.](http://myanimelist.net/anime/16417/Tamako_Market)**\n* **[Tamayura.](http://myanimelist.net/anime/9055/Tamayura)**\n* **[Tari Tari.](http://myanimelist.net/anime/13333/Tari_Tari)**\n* **[Teekyuu.](http://myanimelist.net/anime/15125/Teekyuu)**\n* **[Tesagure! Bukatsumono.](http://myanimelist.net/anime/19919/Tesagure!_Bukatsumono)**\n* **[Tesagure! Bukatsumono.](http://myanimelist.net/anime/19919/Tesagure_Bukatsumono)**\n* **[Tonari no seki-kun.](http://myanimelist.net/anime/18139/Tonari_no_Seki-kun)**\n* **[Urawa no Usagi-chan.](http://myanimelist.net/anime/27927/Urawa_no_Usagi-chan)**\n* **[Wakaba Girl.](http://myanimelist.net/anime/30355/Wakaba*Girl)**\n* **[Working!!](http://myanimelist.net/anime/6956/Working!!)**\n* **[Yama no Susume.](http://myanimelist.net/anime/14355/Yama_no_Susume)**\n* **[Yuru Yuri.](http://myanimelist.net/anime/10495/Yuru_Yuri)**\n* **[Yuyushiki.](http://myanimelist.net/anime/15911/Yuyushiki)**\n\n *I am a bot and this was performed automatically. Thanks to UnavailableUsername_ for this list and dabritian for alphabetizing it.[](#heart-thumbs-up)\nIf anyone has any issues with this bot, please PM genericthrowawayyes.\nWant more information about this bot? [Clickly me] (https://www.reddit.com/r/IWantInfoForMyBot/comments/4gegxa/information_on_my_bot/)*\n\n^^^^^^^^^^SOL ^^^^^^^^^^Recommendation ^^^^^^^^^^Bot ^^^^^^^^^^Version 0.1 BETA ^^^^^^^^^^by ^^^^^^^^^^genericthrowawayyes.");
						} 
						catch (Exception ex) 
						{
							Console.Write (ex.Message);
						}
					}
				}
			}
			Console.Write (count.ToString () + " comments posted in the last " + counters.ToString () + " posts of "+subreddit.Name);
			/*
					After initial commenting from startup, start looking for new threads.
			*/
			Console.Write ("\nNow waiting 30 minutes until the next scan... \n");
			DateTime now = DateTime.Now;
			while (((DateTime.Now.Ticks - now.Ticks) / 18000000000) <= 1)  //If 30 minutes haven't passed...
			{
				System.Threading.Thread.Sleep (300000); //Sleep for 6 minutes
				switch ((DateTime.Now.Ticks - now.Ticks) / 180000000) //Even though these percenteges are wrong, keep em anyways.
				//Todo, maybe fix this? It's more aesthetical than practical, and it's not exactly wrong, it just isn't right...
				{
					case 16:
						Console.Write ("\n 0% complete of waiting. @ "+DateTime.Now.ToLocalTime().ToShortTimeString()); //Write how close to completion we is
						break;
					case 33:
						Console.Write ("\n 20% complete of waiting. @ "+DateTime.Now.ToLocalTime().ToShortTimeString()); //Write how close to completion we is
						break;
					case 50:
						Console.Write ("\n 40% complete of waiting. @ "+DateTime.Now.ToLocalTime().ToShortTimeString()); //Write how close to completion we is
						break;
					case 66:
						Console.Write ("\n 60% complete of waiting. @ "+DateTime.Now.ToLocalTime().ToShortTimeString()); //Write how close to completion we is
						break;
					case 83:
						Console.Write ("\n 80% complete of waiting. @ "+DateTime.Now.ToLocalTime().ToShortTimeString()); //Write how close to completion we is
						break;
					case 100:
						Console.Write ("\n 100% complete of waiting. @ "+DateTime.Now.ToLocalTime().ToShortTimeString()); //Write how close to completion we is
						break;
					default: 
						Console.Write ("Error in switch statement --- Check it out");
						break;
				}
				//Console.Write ("\n"+(DateTime.Now.Ticks - now.Ticks) / 180000000+"% complete of waiting. @ "+DateTime.Now.ToLocalTime().ToShortTimeString()); //Write how close to completion we is

			}
			Console.Write ("\nFinished waiting 30 minutes... Proceeding to start again.\n");
			postComment ();
			//Restart the process of searching through the subreddit, commenting where available etc.
		}
		public static string ReadPassword() //This method replaces the text in the console to *'s.
		{
			var passbits = new Stack<string>();
			for (ConsoleKeyInfo cki = Console.ReadKey(true); cki.Key != ConsoleKey.Enter; cki = Console.ReadKey(true))
			{
				if (cki.Key == ConsoleKey.Backspace)
				{
					if (passbits.Count() > 0)
					{
						//rollback the cursor and write a space so it looks backspaced to the user
						Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
						Console.Write(" ");
						Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
						passbits.Pop();
					}
				}
				else
				{
					Console.Write("*");
					passbits.Push(cki.KeyChar.ToString());
				}
			}
			string[] pass = passbits.ToArray();
			Array.Reverse(pass);
			Console.Write(Environment.NewLine);
			return string.Join(string.Empty, pass);
		} 
	}
}
