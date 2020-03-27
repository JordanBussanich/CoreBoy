using System;
using System.Collections.Generic;

namespace CoreBoy
{
    public partial class CPU
    {
        private void InitialiseOperations()
        {
            var ops = new Ops(this);

            // 0x00 - NOP
            Operations.Add(0x00, ops.NOP());      

            // 0x01 - LD BC,nn
            Operations.Add(0x01, ops.LD_16(Register16BitNames.BC));

            // 0x02 - LD (BC), A
            Operations.Add(0x02, ops.LD_8(Register8BitNames.A, Register16BitNames.BC));

            // 0x04 - INC B
            Operations.Add(0x04, ops.INC_8(Register8BitNames.B));

            // 0x05 - DEC B
            Operations.Add(0x05, ops.DEC_8(Register8BitNames.B));

            // 0x06 - LD B,n
            Operations.Add(0x06, ops.LD_8(Register8BitNames.B));

            // 0x07 RLCA
            Operations.Add(0x07, ops.RLCA());

            // 0x08 LD (nn), SP
            Operations.Add(0x08, ops.LD_16_SP());

            // 0x09 - ADD HL,BC
            Operations.Add(0x09, ops.ADD_16(Register16BitNames.BC));

            // 0x02 - LD (DE), A
            Operations.Add(0x12, ops.LD_8(Register8BitNames.A, Register16BitNames.DE));

            // 0x0B - DEC BC
            Operations.Add(0x0B, ops.DEC_16(Register16BitNames.BC));

            // 0x0C - INC C
            Operations.Add(0x0C, ops.INC_8(Register8BitNames.C));

            // 0x0D - DEC C
            Operations.Add(0x0D, ops.DEC_8(Register8BitNames.C));

            // 0x0E - LD C,n
            Operations.Add(0x0E, ops.LD_8(Register8BitNames.C));

            // 0x11 - LD DE,nn
            Operations.Add(0x11, ops.LD_16(Register16BitNames.DE));

            // 0x14 - INC D
            Operations.Add(0x14, ops.INC_8(Register8BitNames.D));

            // 0x15 - DEC D
            Operations.Add(0x15, ops.DEC_8(Register8BitNames.D));

            // 0x16 - LD D,n
            Operations.Add(0x16, ops.LD_8(Register8BitNames.D));

            // 0x19 - ADD HL,DE
            Operations.Add(0x19, ops.ADD_16(Register16BitNames.DE));

            // 0x1B - DEC DE
            Operations.Add(0x1B, ops.DEC_16(Register16BitNames.DE));

            // 0x1C - INC E
            Operations.Add(0x1C, ops.INC_8(Register8BitNames.E));

            // 0x1D - DEC E
            Operations.Add(0x1D, ops.DEC_8(Register8BitNames.E));

            // 0x1E - LD E,n
            Operations.Add(0x1E, ops.LD_8(Register8BitNames.E));

            // 0x1F - RRA
            Operations.Add(0x1F, ops.RRA());

            // 0x20 - JR NZ,n
            Operations.Add(0x20, ops.JR(JRFlags.NZ));

            // 0x21 - LD HL,nn
            Operations.Add(0x21, ops.LD_16(Register16BitNames.HL));

            // 0x24 - INC H
            Operations.Add(0x24, ops.INC_8(Register8BitNames.H));

            // 0x25 - DEC H
            Operations.Add(0x25, ops.DEC_8(Register8BitNames.H));

            // 0x26 - LD H,n
            Operations.Add(0x26, ops.LD_8(Register8BitNames.H));

            // 0x28 - JR Z,n
            Operations.Add(0x28, ops.JR(JRFlags.Z));

            // 0x29 - ADD HL,HL
            Operations.Add(0x29, ops.ADD_16(Register16BitNames.HL));

            // 0x2A - LDI (HL),A
            Operations.Add(0x2A, ops.LDI(Register8BitNames.A, Register16BitNames.HL));

            // 0x2B - DEC HL
            Operations.Add(0x2B, ops.DEC_16(Register16BitNames.HL));

            // 0x2C - INC L
            Operations.Add(0x2C, ops.INC_8(Register8BitNames.L));

            // 0x2D - DEC L
            Operations.Add(0x2D, ops.DEC_8(Register8BitNames.L));

            // 0x2E - LD H,n
            Operations.Add(0x2E, ops.LD_8(Register8BitNames.L));

            // 0x2F - CPL
            Operations.Add(0x2F, ops.CPL());

            // 0x30 - JR NC,n
            Operations.Add(0x30, ops.JR(JRFlags.NC));

            // 0x31 - LD SP,nn
            Operations.Add(0x31, ops.LD_16(Register16BitNames.SP));

            // 0x32 - LDD (HL),A
            Operations.Add(0x32, ops.LDD(Register8BitNames.A, Register16BitNames.HL));

            // 0x35 - DEC A
            Operations.Add(0x35, ops.DEC_8(Register8BitNames.A));

            // 0x36 - LD HL,n
            Operations.Add(0x36, ops.LD_8(Register16BitNames.HL));

            // 0x38 - JR C,n
            Operations.Add(0x38, ops.JR(JRFlags.C));

            // 0x39 - ADD HL,SP
            Operations.Add(0x39, ops.ADD_16(Register16BitNames.SP));

            // 0x3B - DEC SP
            Operations.Add(0x3B, ops.DEC_16(Register16BitNames.SP));

            // 0x3C - INC A
            Operations.Add(0x3C, ops.INC_8(Register8BitNames.A));

            // 0x3E - LD A,n
            Operations.Add(0x3E, ops.LD_8(Register8BitNames.A));

            // 0x70 - LD (HL), B
            Operations.Add(0x70, ops.LD_8(Register8BitNames.B, Register16BitNames.HL));

            // 0x71 - LD (HL), C
            Operations.Add(0x71, ops.LD_8(Register8BitNames.C, Register16BitNames.HL));

            // 0x72 - LD (HL), D
            Operations.Add(0x72, ops.LD_8(Register8BitNames.D, Register16BitNames.HL));

            // 0x73 - LD (HL), E
            Operations.Add(0x73, ops.LD_8(Register8BitNames.E, Register16BitNames.HL));

            // 0x74 - LD (HL), H
            Operations.Add(0x74, ops.LD_8(Register8BitNames.H, Register16BitNames.HL));

            // 0x75 - LD (HL), L
            Operations.Add(0x75, ops.LD_8(Register8BitNames.L, Register16BitNames.HL));

            // 0x77 - LD (HL), A
            Operations.Add(0x77, ops.LD_8(Register8BitNames.A, Register16BitNames.HL));

            // 0x78 - LD A, B
            Operations.Add(0x78, ops.LD_8(Register8BitNames.B, Register8BitNames.A));

            // 0x79 - LD A, C
            Operations.Add(0x79, ops.LD_8(Register8BitNames.C, Register8BitNames.A));

            // 0x7A - LD A, D
            Operations.Add(0x7A, ops.LD_8(Register8BitNames.D, Register8BitNames.A));

            // 0x7B - LD A, E
            Operations.Add(0x7B, ops.LD_8(Register8BitNames.E, Register8BitNames.A));

            // 0x7C - LD A, H
            Operations.Add(0x7C, ops.LD_8(Register8BitNames.H, Register8BitNames.A));

            // 0x7D - LD A, L
            Operations.Add(0x7D, ops.LD_8(Register8BitNames.L, Register8BitNames.A));

            // 0x7F - LD A, A
            Operations.Add(0x7F, ops.LD_8(Register8BitNames.A, Register8BitNames.A));

            // 0xA0 - AND B
            Operations.Add(0xA0, ops.AND_8(Register8BitNames.B));

            // 0xA1 - AND C
            Operations.Add(0xA1, ops.AND_8(Register8BitNames.C));

            // 0xA2 - AND D
            Operations.Add(0xA2, ops.AND_8(Register8BitNames.D));

            // 0xA3 - AND E
            Operations.Add(0xA3, ops.AND_8(Register8BitNames.E));

            // 0xA4 - AND H
            Operations.Add(0xA4, ops.AND_8(Register8BitNames.H));

            // 0xA5 - AND L
            Operations.Add(0xA5, ops.AND_8(Register8BitNames.L));

            // 0xA7 - AND A
            Operations.Add(0xA7, ops.AND_8(Register8BitNames.A));

            // 0xA8 - XOR B
            Operations.Add(0xA8, ops.XOR_8(Register8BitNames.B));

            // 0xA9 - XOR C
            Operations.Add(0xA9, ops.XOR_8(Register8BitNames.C));

            // 0xAA - XOR D
            Operations.Add(0xAA, ops.XOR_8(Register8BitNames.D));

            // 0xAB - XOR E
            Operations.Add(0xAB, ops.XOR_8(Register8BitNames.E));

            // 0xAC - XOR H
            Operations.Add(0xAC, ops.XOR_8(Register8BitNames.H));

            // 0xAD - XOR L
            Operations.Add(0xAD, ops.XOR_8(Register8BitNames.L));

            // 0xAF - XOR A
            Operations.Add(0xAF, ops.XOR_8(Register8BitNames.A));

            // 0xB0 - OR B
            Operations.Add(0xB0, ops.OR_8(Register8BitNames.B));

            // 0xB1 - OR C
            Operations.Add(0xB1, ops.OR_8(Register8BitNames.C));

            // 0xB2 - OR D
            Operations.Add(0xB2, ops.OR_8(Register8BitNames.D));

            // 0xB3 - OR E
            Operations.Add(0xB3, ops.OR_8(Register8BitNames.E));

            // 0xB4 - OR H
            Operations.Add(0xB4, ops.OR_8(Register8BitNames.H));

            // 0xB5 - OR L
            Operations.Add(0xB5, ops.OR_8(Register8BitNames.L));

            // 0xB7 - OR A
            Operations.Add(0xB7, ops.OR_8(Register8BitNames.A));

            // 0xB8 - CP B
            Operations.Add(0xB8, ops.CP(Register8BitNames.B));

            // 0xB9 - CP C
            Operations.Add(0xB9, ops.CP(Register8BitNames.C));

            // 0xBA - CP D
            Operations.Add(0xBA, ops.CP(Register8BitNames.D));

            // 0xBB - CP E
            Operations.Add(0xBB, ops.CP(Register8BitNames.E));
            
            // 0xBC - CP H
            Operations.Add(0xBC, ops.CP(Register8BitNames.H));

            // 0xBD - CP L
            Operations.Add(0xBD, ops.CP(Register8BitNames.L));

            // 0xBF - CP A
            Operations.Add(0xBF, ops.CP(Register8BitNames.A));

            // 0xC2 - JP NZ,nn
            Operations.Add(0xC2, ops.JP_cc_nn(JRFlags.NZ));

            // 0xC3 - JP, nn
            Operations.Add(0xC3, ops.JP_nn());

            // 0xC9 - RET
            Operations.Add(0xC9, ops.RET());

            // 0xCA - JP Z,nn
            Operations.Add(0xCA, ops.JP_cc_nn(JRFlags.Z));

            // 0xCD - CALL nn
            Operations.Add(0xCD, ops.CALL());

            // 0xD2 - JP NC,nn
            Operations.Add(0xD2, ops.JP_cc_nn(JRFlags.NC));

            // 0xDA - JP C,nn
            Operations.Add(0xDA, ops.JP_cc_nn(JRFlags.C));

            // 0xE0 - LDH (n),A
            Operations.Add(0xE0, ops.LDH_n_A());

            // 0xE2 - LD (0xFF00+C),A
            Operations.Add(0xE2, ops.LD_C_FF00_A());

            // 0xE6 - AND n
            Operations.Add(0xE6, ops.AND_8());

            // 0xEA - LD (nn),A
            Operations.Add(0xEA, ops.LD_8());

            // 0xF0 - LDH A,(n)
            Operations.Add(0xF0, ops.LDH_A_n());

            // 0xF3 - DI
            Operations.Add(0xF3, ops.DI());

            // 0xFB - EI
            Operations.Add(0xFB, ops.EI());

            // 0xFE - CP
            Operations.Add(0xFE, ops.CP());
        }

        public enum JRFlags
        {
            NZ,
            Z,
            NC,
            C
        }

        private class Ops
        {
            private CPU _cpu;

            public Ops(CPU cpu)
            {
                _cpu = cpu;
            }

            public NormalOperation NOP() => new NormalOperation(() =>
            {
                Console.WriteLine("NOP");
            }, "NOP", 4, 1);

            public NormalOperation LD_16(Register16BitNames register) => new NormalOperation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);

                ushort lsByte = _cpu.Memory[currentPC + 0x1];
                ushort msByte = _cpu.Memory[currentPC + 0x2];

                ushort newValue = (ushort)((msByte << 8) | lsByte);

                Console.WriteLine($"LD {register.ToString()}, 0x{newValue.ToString("X4")}");

                _cpu.Registers.SetRegisterValue(register, newValue);

            }, $"LD {register.ToString()}, nn", 12, 3);

            public NormalOperation LD_16_SP() => new NormalOperation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);
                ushort currentSP = _cpu.Registers.GetRegisterValue(Register16BitNames.SP);

                ushort addressLSB = _cpu.Memory[currentPC + 0x1];
                ushort addressMSB = _cpu.Memory[currentPC + 0x2];

                ushort address = (ushort)((addressMSB << 8) | addressLSB);

                Console.WriteLine($"LD (nn), SP, (nn)LS Byte: 0x{addressLSB.ToString("X2")}, (nn)MS Byte: 0x{addressMSB.ToString("X2")}, Value: 0x{address.ToString("X4")}");

                byte spLSB = (byte)((currentSP & 0b_1111_1111_0000_0000) >> 8);
                byte spMSB = (byte)(currentSP & 0b_0000_0000_1111_1111);

                _cpu.Memory[address] = spLSB;
                _cpu.Memory[address + 0x1] = spMSB;
            }, $"LD (nn), SP", 20, 3);

            public NormalOperation LDD(Register8BitNames sourceRegister, Register16BitNames destinationRegister) => new NormalOperation(() =>
            {               
                Console.WriteLine($"LDD {sourceRegister.ToString()}, {destinationRegister.ToString()}");
                
                ushort destinationAddress = _cpu.Registers.GetRegisterValue(destinationRegister);

                byte sourceValue = (byte)(_cpu.Registers.GetRegisterValue(sourceRegister));

                _cpu.Memory[destinationAddress] = sourceValue;

                _cpu.Registers.SetRegisterValue(destinationRegister, --destinationAddress);

            }, $"LDD {sourceRegister.ToString()}, {destinationRegister.ToString()}", 8, 1);

            public NormalOperation LDI(Register8BitNames sourceRegister, Register16BitNames destinationRegister) => new NormalOperation(() =>
            {               
                Console.WriteLine($"LDI {sourceRegister.ToString()}, {destinationRegister.ToString()}");
                
                ushort destinationAddress = _cpu.Registers.GetRegisterValue(destinationRegister);

                byte sourceValue = (byte)(_cpu.Registers.GetRegisterValue(sourceRegister));

                _cpu.Memory[destinationAddress] = sourceValue;

                _cpu.Registers.SetRegisterValue(destinationRegister, ++destinationAddress);

            }, $"LDI {sourceRegister.ToString()}, {destinationRegister.ToString()}", 8, 1);

            public NormalOperation LD_C_FF00_A() => new NormalOperation(() =>
            {
                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);
                byte currentC = _cpu.Registers.GetRegisterValue(Register8BitNames.C);

                ushort newAddress = (ushort)(currentC + 0xFF00);

                _cpu.Memory[newAddress] = currentA;

                Console.WriteLine($"LD 0x{newAddress.ToString("X4")}, A");
            }, $"LD ($FF00+C),A", 8, 1);
            
            public NormalOperation LD_8(Register8BitNames register) => new NormalOperation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);

                byte value = _cpu.Memory[currentPC + 0x1];

                Console.WriteLine($"LD {register.ToString()}, 0x{value.ToString("X2")}");

                _cpu.Registers.SetRegisterValue(register, value);
            }, $"LD {register.ToString()}, nn", 8, 2);

            public NormalOperation LD_8(Register16BitNames register) => new NormalOperation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);

                byte value = _cpu.Memory[currentPC + 0x1];

                Console.WriteLine($"LD {register.ToString()}, 0x{value.ToString("X2")}");

                _cpu.Registers.SetRegisterValue(register, value);
            }, $"LD {register.ToString()}, nn", 12, 2);

            public NormalOperation LD_8(Register8BitNames source, Register8BitNames target) => new NormalOperation(() =>
            {
                Console.WriteLine($"LD {target.ToString()}, {source.ToString()}");

                byte sourceValue = _cpu.Registers.GetRegisterValue(source);
                _cpu.Registers.SetRegisterValue(target, sourceValue);
            }, $"LD {target.ToString()}, {source.ToString()}", 4, 1);

            public NormalOperation LD_8(Register8BitNames source, Register16BitNames target) => new NormalOperation(() =>
            {
                Console.WriteLine($"LD {target.ToString()}, {source.ToString()}");

                byte sourceValue = _cpu.Registers.GetRegisterValue(source);
                _cpu.Registers.SetRegisterValue(target, sourceValue);
            }, $"LD {target.ToString()}, {source.ToString()}", 8, 1);

            public NormalOperation LD_8() => new NormalOperation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);

                ushort lsByte = _cpu.Memory[currentPC + 0x1];
                ushort msByte = _cpu.Memory[currentPC + 0x2];

                ushort newValue = (ushort)((msByte << 8) | lsByte);

                _cpu.Memory[newValue] = _cpu.Registers.GetRegisterValue(Register8BitNames.A);

                Console.WriteLine($"LD 0x{newValue.ToString("X4")}, A");
            }, $"LD (nn),A", 16, 3);

            public NormalOperation DEC_8(Register8BitNames register) => new NormalOperation(() =>
            {
                Console.WriteLine($"DEC {register.ToString()}");

                byte operand = _cpu.Registers.GetRegisterValue(register);
                byte result = --operand;

                _cpu.Registers.SetRegisterValue(register, result);

                _cpu.Registers.ZZeroFlag = result == 0;
                _cpu.Registers.NSubtractFlag = true;
                _cpu.Registers.HHalfCarryFlag = operand == 0b_0001_0000;

            }, $"DEC {register.ToString()}", 4, 1);

            public NormalOperation DEC_16(Register16BitNames register) => new NormalOperation(() =>
            {
                Console.WriteLine($"DEC {register.ToString()}");

                ushort operand = _cpu.Registers.GetRegisterValue(register);
                ushort result = --operand;

                _cpu.Registers.SetRegisterValue(register, result);

            }, $"DEC {register.ToString()}", 8, 1);

            public NormalOperation INC_8(Register8BitNames register) => new NormalOperation(() =>
            {
                Console.WriteLine($"INC {register.ToString()}");

                byte operand = _cpu.Registers.GetRegisterValue(register);
                byte result = (byte)(operand + 1);

                _cpu.Registers.SetRegisterValue(register, result);

                _cpu.Registers.ZZeroFlag = result == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = result == 0b_0001_0000;

            }, $"INC {register.ToString()}", 4, 1);

            public NormalOperation OR_8(Register8BitNames register) => new NormalOperation(() =>
            {
                Console.WriteLine($"OR {register.ToString()}");

                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);
                byte operand = _cpu.Registers.GetRegisterValue(register);

                byte result = (byte)(currentA | operand);

                _cpu.Registers.ZZeroFlag = result == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = false;
                _cpu.Registers.CCarryFlag = false;

            }, $"OR {register.ToString()}", 4, 1);

            public JumpOperation JR(JRFlags flag) => new JumpOperation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);
                ushort newAddress = 0;
                bool jump = false;

                switch (flag)
                {
                    case (JRFlags.NZ):
                        if (!_cpu.Registers.ZZeroFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.Z):
                        if (_cpu.Registers.ZZeroFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.NC):
                        if (!_cpu.Registers.CCarryFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.C):
                        if (_cpu.Registers.CCarryFlag)
                        {
                            jump = true;
                        }
                        break;
                }

                if (jump)
                {
                    newAddress = (ushort)((sbyte)(_cpu.Memory[currentPC + 1] + 1) + currentPC + 1);
                }
                else
                {
                    newAddress = (ushort)(currentPC + 2);
                }

                Console.WriteLine($"JR {flag.ToString()}, 0x{_cpu.Memory[currentPC + 1].ToString("X2")}");

                _cpu.Registers.SetRegisterValue(Register16BitNames.PC, newAddress);

                return jump;
            }, $"JR {flag.ToString()}, n", 12, null, 8);

            public JumpOperation JP_cc_nn(JRFlags flag) => new JumpOperation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);
                ushort newAddress = 0;
                bool jump = false;

                switch (flag)
                {
                    case (JRFlags.NZ):
                        if (!_cpu.Registers.ZZeroFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.Z):
                        if (_cpu.Registers.ZZeroFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.NC):
                        if (!_cpu.Registers.CCarryFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.C):
                        if (_cpu.Registers.CCarryFlag)
                        {
                            jump = true;
                        }
                        break;
                }

                if (jump)
                {
                    ushort addressLSB = _cpu.Memory[currentPC + 0x1];
                    ushort addressMSB = _cpu.Memory[currentPC + 0x2];

                    newAddress = (ushort)(addressLSB | (ushort)(addressMSB << 8));
                }
                else
                {
                    newAddress = (ushort)(currentPC + 2);
                }

                Console.WriteLine($"JP {flag.ToString()}, 0x{newAddress.ToString("X4")}");

                _cpu.Registers.SetRegisterValue(Register16BitNames.PC, newAddress);

                return jump;
            }, $"JP {flag.ToString()}, nn", 16, null, 12);

            public NormalOperation RRA() => new NormalOperation(() =>
            {
                Console.WriteLine("RRA");

                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);
                
                byte newCarry = (byte)(currentA & 0b_0000_0001);
                byte newBit7 = (byte)((_cpu.Registers.CCarryFlag ? (byte)0x1 : (byte)0x0) << 7);

                byte newA = (byte)((byte)(currentA >> 1) | newBit7);

                _cpu.Registers.ZZeroFlag = newA == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = false;
                _cpu.Registers.CCarryFlag = newCarry == 0x1;
                
                _cpu.Registers.SetRegisterValue(Register8BitNames.A, newA);
            }, "RRA", 4, 1);

            public NormalOperation XOR_8(Register8BitNames parameter) => new NormalOperation(() =>
            {
                Console.WriteLine($"XOR {parameter.ToString()}");

                byte registerA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);
                byte parameterRegister = _cpu.Registers.GetRegisterValue(parameter);

                byte result = (byte)(registerA ^ parameterRegister);

                _cpu.Registers.ZZeroFlag = result == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = false;
                _cpu.Registers.CCarryFlag = false;

                _cpu.Registers.SetRegisterValue(Register8BitNames.A, result);
                
            }, $"XOR {parameter.ToString()}", 4, 1);           

            public JumpOperation JP_nn() => new JumpOperation(() =>
            {
                ushort nextPC = (ushort)(_cpu.Registers.GetRegisterValue(Register16BitNames.PC) + 0x1);
                
                ushort addressLsb = _cpu.Memory[nextPC];
                ushort addressMsb = _cpu.Memory[(ushort)(nextPC + 0x1)];

                ushort address = (ushort)((ushort)(addressMsb << 8) | addressLsb);

                Console.WriteLine($"JP 0x{address.ToString("X4")}");

                _cpu.Registers.SetRegisterValue(Register16BitNames.PC, address);

                return true;
            }, $"JP nn", 16, null, 16);

            public NormalOperation CP(Register8BitNames register) => new NormalOperation(() =>
            {
                Console.WriteLine($"CP {register.ToString()}");

                byte parameter = _cpu.Registers.GetRegisterValue(register);
                
                CP(parameter);
            }, $"CP {register.ToString()}", 4, 1);

            public NormalOperation CP() => new NormalOperation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);
                
                byte parameter = _cpu.Memory[currentPC + 0x1];

                Console.WriteLine($"CP 0x{parameter.ToString("X2")}");

                CP(parameter);               
            }, $"CP n", 8, 2);

            private void CP(byte parameter)
            {
                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);

                bool currentABit3 = (byte)(((byte)(currentA >> 3)) & 0b_0000_0001) == 0b_1;
                bool parameterBit3 = (byte)(((byte)(parameter >> 3)) & 0b_0000_0001)  == 0b_1;

                _cpu.Registers.ZZeroFlag = currentA == parameter;
                _cpu.Registers.NSubtractFlag = true;
                _cpu.Registers.HHalfCarryFlag = !currentABit3 && parameterBit3;
                _cpu.Registers.CCarryFlag = currentA < parameter;
            }

            public NormalOperation ADD_16(Register16BitNames register) => new NormalOperation(() =>
            {
                Console.WriteLine($"ADD HL, {register.ToString()}");

                ushort currentHL = _cpu.Registers.GetRegisterValue(Register16BitNames.HL);
                ushort operand = _cpu.Registers.GetRegisterValue(register);

                ushort result = (ushort)(currentHL + operand);

                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = (currentHL + operand) > 0xFFF;
                _cpu.Registers.CCarryFlag = (currentHL + operand) > ushort.MaxValue;

                _cpu.Registers.SetRegisterValue(Register16BitNames.HL, result);
            }, $"ADD HL, {register.ToString()}", 8, 1);

            public NormalOperation RLCA() => new NormalOperation(() =>
            {
                Console.WriteLine("RLCA");

                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);

                byte newLsb = (byte)(currentA >> 7);

                byte shifted = (byte)((byte)(currentA << 1) | newLsb);

                _cpu.Registers.ZZeroFlag = shifted == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = false;
                _cpu.Registers.CCarryFlag = newLsb == 0x1;
            }, $"RLCA", 4, 1);

            public NormalOperation DI() => new NormalOperation(() =>
            {
                Console.WriteLine("DI");

                CPU.DIHelper.DisableInterruptsAfterNextInstruction = true;
            }, $"DI", 4, 1);
            
            public NormalOperation EI() => new NormalOperation(() =>
            {
                Console.WriteLine("EI");

                CPU.EIHelper.EnableInterruptsAfterNextInstruction = true;
            }, $"EI", 4, 1);


            public NormalOperation LDH_n_A() => new NormalOperation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);
                byte offset = _cpu.Memory[currentPC + 0x1];

                Console.WriteLine($"LDH 0x{offset.ToString("X2")}, A");

                ushort newAddress = (ushort)(0xFF00 + offset);

                _cpu.Memory[newAddress] = _cpu.Registers.GetRegisterValue(Register8BitNames.A);
            }, $"LDH (n),A", 12, 2);

            public NormalOperation LDH_A_n() => new NormalOperation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);
                byte offset = _cpu.Memory[currentPC + 0x1];

                Console.WriteLine($"LDH A, 0x{offset.ToString("X2")}");

                ushort newAddress = (ushort)(0xFF00 + offset);

                _cpu.Registers.SetRegisterValue(Register8BitNames.A, _cpu.Memory[newAddress]);
            }, $"LDH A,(n)", 12, 2);

            public NormalOperation CPL() => new NormalOperation(() =>
            {
                Console.WriteLine("CPL");

                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);

                _cpu.Registers.NSubtractFlag = true;
                _cpu.Registers.HHalfCarryFlag = true;

                _cpu.Registers.SetRegisterValue(Register8BitNames.A, (byte)~currentA);
            }, $"CPL", 4, 1);

            public NormalOperation AND_8() => new NormalOperation(() =>
            {
                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);

                byte operand = _cpu.Memory[currentPC + 1];

                Console.WriteLine($"AND {operand.ToString("X2")}");

                byte result = (byte)(currentA & operand);

                _cpu.Registers.ZZeroFlag = result == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = true;
                _cpu.Registers.CCarryFlag = false;

                _cpu.Registers.SetRegisterValue(Register8BitNames.A, result);
            }, $"AND n", 8, 2);

            public NormalOperation AND_8(Register8BitNames register) => new NormalOperation(() =>
            {
                Console.WriteLine($"AND {register.ToString()}");

                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);
                byte operand = _cpu.Registers.GetRegisterValue(register);

                byte result = (byte)(currentA & operand);

                _cpu.Registers.ZZeroFlag = result == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = true;
                _cpu.Registers.CCarryFlag = false;

                _cpu.Registers.SetRegisterValue(Register8BitNames.A, result);
            }, $"AND n", 4, 1);

            public NormalOperation CALL() => new NormalOperation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);
                byte jumpLsb = _cpu.Memory[currentPC + 0x1];
                byte jumpMsb = _cpu.Memory[currentPC + 0x2];

                Console.WriteLine($"CALL 0x{jumpMsb.ToString("X2")}{jumpLsb.ToString("X2")}");

                CALL(jumpMsb, jumpLsb);
            }, $"CALL nn", 12, null);

            public NormalOperation RET() => new NormalOperation(() =>
            {
                Console.WriteLine("RET");

                byte newMsb = POP();
                byte newLsb = POP();

                ushort newAddress = (ushort)(((ushort)newMsb << 8) | newLsb);

                _cpu.Registers.SetRegisterValue(Register16BitNames.PC, newAddress);
            }, $"RET", 8, null);

            private void CALL(byte jumpMsb, byte jumpLsb)
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);
                ushort returnAddress = (ushort)(currentPC + 0x3);

                PUSHAddress(returnAddress);

                ushort newAddress = (ushort)(((ushort)jumpMsb << 8) | jumpLsb);

                _cpu.Registers.SetRegisterValue(Register16BitNames.PC, newAddress);
            }

            private void PUSH(byte value)
            {
                ushort currentSP = _cpu.Registers.GetRegisterValue(Register16BitNames.SP);
                _cpu.Registers.SetRegisterValue(Register16BitNames.SP, --currentSP);

                _cpu.Memory[currentSP] = value;
            }

            private void PUSHAddress(ushort address)
            {
                byte addressMSB = (byte)((address & 0b_1111_1111_0000_0000) >> 8);
                byte addressLSB = (byte)(address & 0b_0000_0000_1111_1111);

                PUSH(addressLSB);
                PUSH(addressMSB);
            }

            private byte POP()
            {
                byte result;

                ushort currentSP = _cpu.Registers.GetRegisterValue(Register16BitNames.SP);
                result = _cpu.Memory[currentSP];

                _cpu.Registers.SetRegisterValue(Register16BitNames.SP, ++currentSP);

                return result;
            }
        }
    }
}