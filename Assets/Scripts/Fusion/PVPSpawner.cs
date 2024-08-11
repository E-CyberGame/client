using System.Linq;
using Fusion;
using TMPro;
using UnityEngine;

public class PVPSpawner : SimulationBehaviour, IPlayerJoined
                          {
                              public GameObject SearchRoom;
                              public GameObject Player1Prefab;
                              public GameObject Player2Prefab;
                          
                              public GameObject Matching;
                          
                              public GameObject PlayerUI;
                              [Networked] public bool isWorker { get; set; } = true;
                              //[Networked] public bool isPlayer1Ready { get; set; } = false;
                              //[Networked] public bool isPlayer2Ready { get; set; } = false;
                          
                              /*public void Player1isReady()
                              {
                                  if(isWorker){
                                      isPlayer1Ready = true;
                                      ReadyText1.text = "GO!";
                                  }
                              }
                              
                              public void Player2isReady()
                              {
                                  if (!isWorker)
                                  {
                                      isPlayer2Ready = true;
                                      ReadyText2.text = "GO!";
                                  }
                              }*/
                              
                              public void PlayerJoined(PlayerRef player)
                              {
                                  if (Runner.ActivePlayers.Count() == 2)
                                  {
                                      Matching.SetActive(false);
                                      PlayerUI.SetActive(true);
                                  }
                                  if (player == Runner.LocalPlayer)
                                  {
                                      Debug.Log(Runner.ActivePlayers.Count());
                                      SearchRoom.SetActive(false);
                                      Matching.SetActive(true);
                                      if (Runner.ActivePlayers.Count() == 1)
                                      {
                                          NetworkObject networkObject = Runner.Spawn(Player1Prefab, new Vector3(-7, 1, 0), Quaternion.identity);
                                          networkObject.name = "MyPlayer";
                                          isWorker = true;
                                      }
                                      else
                                      {
                                          NetworkObject networkObject = Runner.Spawn(Player2Prefab, new Vector3(7, 1, 0), Quaternion.identity);
                                          networkObject.name = "MyPlayer";
                                          isWorker = false;
                                      }
                                  }
                              }
                          }
