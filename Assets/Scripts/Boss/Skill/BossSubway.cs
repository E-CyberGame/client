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
            Debug.Log("���� ����");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("��ź ��ȯ");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(12.0f);
            Debug.Log("��ġ�� ����");
            yield return new WaitForSeconds(6.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(9.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("�ݺ��Ǵ� �ð�");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("��ź ��ȯ + ������ or ����");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("��ź ��ȯ + ������ or ����");
            yield return new WaitForSeconds(15.0f);
            Debug.Log("���� ȸ��");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("�");
            yield return new WaitForSeconds(20.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("��ź ��ȯ");
            yield return new WaitForSeconds(15.0f);
            Debug.Log("� + ������");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(6.0f);
            Debug.Log("���� ��, ���� ��");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("��ź + ������ or ����");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("��ġ��");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(2.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(15.0f);
            Debug.Log("�");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("��ź + ������ or ����");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("���� ��");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("��ź + ������ or ����");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("� + ������");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("�ݺ��Ǵ� �ð�");
            yield return new WaitForSeconds(7.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("����� ���� ����");
            yield return new WaitForSeconds(20.0f);
            Debug.Log("�����");
        }
    }
}

