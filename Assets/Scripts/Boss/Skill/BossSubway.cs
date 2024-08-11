using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Boss.Skill
{
    public class BossSubway : MonoBehaviour
    {
        // �ӽ� �ø�������� �ʵ�
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
            Debug.Log("���� ����");
            Boss_Subway.SetActive(true);
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            horizontal.Lay(new int[] { 0, 5 });
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            horizontal.Lay(new int[] { 2, 4 });
            yield return new WaitForSeconds(3.0f);
            Debug.Log("�");
            fall.Fall(new int[] { 0, 1, 2, 6, 14, 15, 17, 19, 21 });
            yield return new WaitForSeconds(3.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            vertical.Lay(new int[] { 0, 3, 12, 15, 19 });
            yield return new WaitForSeconds(5.0f);
            Debug.Log("��ź ��ȯ");
            bomb.Bomb(new int[] { 0, 5, 10, 15, 20 });
            yield return new WaitForSeconds(7.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("���� ��");
            horizontal.Lay(new int[] { 0, 1 });
            yield return new WaitForSeconds(12.0f);
            Debug.Log("��ġ�� ����");
            yield return new WaitForSeconds(6.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(9.0f);
            Debug.Log("���� ��");
            vertical.Lay(new int[] { 0, 5, 7, 11, 18, 19 });
            yield return new WaitForSeconds(7.0f);
            Debug.Log("���� ��");
            vertical.Lay(new int[] { 0, 1, 2, 6, 14, 15, 17, 19, 21 });
            yield return new WaitForSeconds(8.0f);
            Debug.Log("�ݺ��Ǵ� �ð�");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            vertical.Lay(new int[] { 1, 6, 8, 11, 12, 18, 20 });
            yield return new WaitForSeconds(10.0f);
            Debug.Log("��ź ��ȯ + ������ or ����");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("��ź ��ȯ + ������ or ����");
            yield return new WaitForSeconds(15.0f);
            Debug.Log("���� ȸ��");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("�");
            fall.Fall(new int[] { 0, 1, 2, 6, 14, 15, 17, 19, 21 });
            yield return new WaitForSeconds(20.0f);
            Debug.Log("���� ��");
            horizontal.Lay(new int[] { 0, 5 });
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            vertical.Lay(new int[] { 0, 5, 7, 11, 18, 19 });
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            horizontal.Lay(new int[] { 2, 4 });
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            vertical.Lay(new int[] { 0, 3, 12, 15, 19 });
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
            horizontal.Lay(new int[] { 0, 5 });
            vertical.Lay(new int[] { 1, 6, 8, 11, 12, 18, 20 });
            yield return new WaitForSeconds(7.0f);
            Debug.Log("��ź + ������ or ����");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("��ġ��");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(2.0f);
            Debug.Log("���� ��");
            vertical.Lay(new int[] { 0, 1, 2, 6, 14, 15, 17, 19, 21 });
            yield return new WaitForSeconds(15.0f);
            Debug.Log("�");
            yield return new WaitForSeconds(8.0f);
            Debug.Log("���� or ���");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("���� ��");
            horizontal.Lay(new int[] { 0, 5 });
            yield return new WaitForSeconds(7.0f);
            Debug.Log("��ź + ������ or ����");
            yield return new WaitForSeconds(10.0f);
            Debug.Log("���� ��");
            vertical.Lay(new int[] { 2, 7, 10, 11, 15, 16, 20, 21 });
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

