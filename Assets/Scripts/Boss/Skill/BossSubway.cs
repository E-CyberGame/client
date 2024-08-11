using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Boss.Skill
{
    public class BossSubway : MonoBehaviour
    {
        // 임시 시리얼라이즈 필드
        [SerializeField] LaySource horizontal;
        [SerializeField] LaySource vertical;
        [SerializeField] FallSource fall;
        [SerializeField] BombSource bomb;
        [SerializeField] GameObject Boss_Subway;


        public static BossSubway Singleton
        {
            get => _subwaysingleton;
            set
            {
                if (value == null)
                    _subwaysingleton = null;
                else if (_subwaysingleton == null)
                    _subwaysingleton = value;
                else if (_subwaysingleton != value)
                {
                    Destroy(value);
                    Debug.LogError($"There should only ever be one instance of {nameof(NetUIMananger)}!");
                }
            }
        }
        private static BossSubway _subwaysingleton;


        public void Awake()
        {
            Singleton = this;
        }

        private void OnDestroy()
        {
            if (Singleton == this)
                Singleton = null;
        }



        public void SkillStart()
        {
            StartCoroutine(SubwaySkill());
        }

        IEnumerator SubwaySkill()
        {
            Debug.Log("게임 시작");
            Boss_Subway.SetActive(true);
            yield return new WaitForSeconds(5.0f);
            Debug.Log("가로 빔");
            horizontal.Lay(new int[] { 0, 5 });
            yield return new WaitForSeconds(5.0f);
            Debug.Log("가로 빔");
            horizontal.Lay(new int[] { 2, 4 });
            yield return new WaitForSeconds(3.0f);
            Debug.Log("운석");
            fall.Fall(new int[] { 0, 1, 2, 6, 14, 15, 17, 19, 21 });
            yield return new WaitForSeconds(3.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("세로 빔");
            vertical.Lay(new int[] { 0, 3, 12, 15, 19 });
            yield return new WaitForSeconds(5.0f);
            Debug.Log("폭탄 소환");
            bomb.Bomb(new int[] { 0, 5, 10, 15, 20 });
            yield return new WaitForSeconds(7.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("가로 빔");
            horizontal.Lay(new int[] { 0, 1 });
            yield return new WaitForSeconds(12.0f);
            Debug.Log("밀치기 시작");
            yield return new WaitForSeconds(6.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(9.0f);
            Debug.Log("세로 빔");
            vertical.Lay(new int[] { 0, 5, 7, 11, 18, 19 });
            yield return new WaitForSeconds(7.0f);
            Debug.Log("세로 빔");
            vertical.Lay(new int[] { 0, 1, 2, 6, 14, 15, 17, 19, 21 });
            yield return new WaitForSeconds(8.0f);
            Debug.Log("반복되는 시간");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("세로 빔");
            vertical.Lay(new int[] { 1, 6, 8, 11, 12, 18, 20 });
            yield return new WaitForSeconds(10.0f);
            Debug.Log("폭탄 소환 + 지연술 or 급행");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("폭탄 소환 + 지연술 or 급행");
            yield return new WaitForSeconds(15.0f);
            Debug.Log("보스 회복");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("운석");
            fall.Fall(new int[] { 0, 1, 2, 6, 14, 15, 17, 19, 21 });
            yield return new WaitForSeconds(20.0f);
            Debug.Log("가로 빔");
            horizontal.Lay(new int[] { 0, 5 });
            yield return new WaitForSeconds(5.0f);
            Debug.Log("세로 빔");
            vertical.Lay(new int[] { 0, 5, 7, 11, 18, 19 });
            yield return new WaitForSeconds(5.0f);
            Debug.Log("가로 빔");
            horizontal.Lay(new int[] { 2, 4 });
            yield return new WaitForSeconds(5.0f);
            Debug.Log("세로 빔");
            vertical.Lay(new int[] { 0, 3, 12, 15, 19 });
            yield return new WaitForSeconds(8.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("폭탄 소환");
            yield return new WaitForSeconds(15.0f);
            Debug.Log("운석 + 지연술");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(6.0f);
            Debug.Log("가로 빔, 세로 빔");
            horizontal.Lay(new int[] { 0, 5 });
            vertical.Lay(new int[] { 1, 6, 8, 11, 12, 18, 20 });
            yield return new WaitForSeconds(7.0f);
            Debug.Log("폭탄 + 지연술 or 급행");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("밀치기");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(2.0f);
            Debug.Log("세로 빔");
            vertical.Lay(new int[] { 0, 1, 2, 6, 14, 15, 17, 19, 21 });
            yield return new WaitForSeconds(15.0f);
            Debug.Log("운석");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("가로 빔");
            horizontal.Lay(new int[] { 0, 5 });
            yield return new WaitForSeconds(7.0f);
            Debug.Log("폭탄 + 지연술 or 급행");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("세로 빔");
            vertical.Lay(new int[] { 2, 7, 10, 11, 15, 16, 20, 21 });
            yield return new WaitForSeconds(8.0f);
            Debug.Log("폭탄 + 지연술 or 급행");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("운석 + 지연술");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("반복되는 시간");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("전멸기 시전 시작");
            yield return new WaitForSeconds(20.0f);
            Debug.Log("전멸기");
        }
    }
}

