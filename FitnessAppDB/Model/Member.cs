﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppDB.Model
{
    public class Member
    {
        private int memberId;
        private MemberInfo memberInfoId;
        private DateTime dateRegistrated;
        private DateTime dateExpiration;

        public int MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }

        public MemberInfo MemberInfoId
        {
            get { return memberInfoId; }
            set { memberInfoId = value; }
        }

        public DateTime DateRegistrated
        {
            get { return dateRegistrated; }
            set { dateRegistrated = value; }
        }

        public DateTime DateExpiration
        {
            get { return dateExpiration; }
            set { dateExpiration = value; }
        }

        PersonDbContext personDbContext = new PersonDbContext();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Card id: { this.MemberId}");
            sb.AppendLine(personDbContext.MemberInfos.Find(this.MemberId).ToString());

            var daysLeft = (this.DateExpiration - DateTime.Now).Days;
            sb.AppendLine($"Days left: {daysLeft}");

            return sb.ToString();
        }
    }
}
