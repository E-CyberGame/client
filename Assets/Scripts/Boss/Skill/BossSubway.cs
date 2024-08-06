using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss.Skill
{
    public class BossSubway : MonoBehaviour
    {
        public void SkillStart()
        {
            StartCoroutine(SubwaySkill());
        }

        IEnumerator SubwaySkill()
        {
            Debug.Log("게임 시작");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("가로 빔");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("가로 빔");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("세로 빔");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("폭탄 소환");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("가로 빔");
            yield return new WaitForSeconds(12.0f);
            Debug.Log("밀치기 시작");
            yield return new WaitForSeconds(6.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(9.0f);
            Debug.Log("세로 빔");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("세로 빔");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("반복되는 시간");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("세로 빔");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("폭탄 소환 + 지연술 or 급행");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("폭탄 소환 + 지연술 or 급행");
            yield return new WaitForSeconds(15.0f);
            Debug.Log("보스 회복");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("운석");
            yield return new WaitForSeconds(20.0f);
            Debug.Log("가로 빔");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("세로 빔");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("가로 빔");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("세로 빔");
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
            yield return new WaitForSeconds(7.0f);
            Debug.Log("폭탄 + 지연술 or 급행");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("밀치기");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(2.0f);
            Debug.Log("세로 빔");
            yield return new WaitForSeconds(15.0f);
            Debug.Log("운석");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("베기 or 찌르기");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("가로 빔");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("폭탄 + 지연술 or 급행");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("세로 빔");
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

