﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.scripts.Utils;
using C2GNet;
using NetWork;
using Services;

namespace GameLogic
{
    public class CharacterManager :Service
    {
        List<Character> characterList_ = new List<Character>();

        EventSystem eventSystem;
        protected internal override void AfterInitailize()
        {
            base.AfterInitailize();
            eventSystem = ServiceLocator.Get<EventSystem>();
        }

        public void InitCharacters() {

            NRoom room=  ServiceLocator.Get<User>().NRoom;

            foreach (AllTeam team in room.AllTeam) {
                foreach (RoomUser roomUser in team.Team) {
                    int index = team.Team.IndexOf(roomUser);
                    CreateCharacter(roomUser,index);
                }
            }
        }
        public void CreateCharacter(RoomUser roomUser,int index) {
            Character character = new Character();




            character.Userid = roomUser.UserId;
            character.Nickname = roomUser.NickName;
            character.Teamid = roomUser.TeamId;
            character.CCharacterId = roomUser.CCharacterId;
            character.Positionid = index;
 
            AddCharacter(character);
        }


        public void AddCharacter(Character character) {
            characterList_.Add(character);
        }
        public List<Character> GetCharacterList() { 
            return characterList_;  
        }
        public void RemoveCharacter(Character character) { 
            if (characterList_.Contains(character))
            {
                characterList_.Remove(character);
            }
        }
    }
}
